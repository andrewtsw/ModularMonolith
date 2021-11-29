using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfIntegration.Shared.Credential;

namespace TCO.SNT.EsfApi.Implementation.Session
{
    internal class EsfApiSessionFactory : IEsfApiSessionFactory
    {
        private readonly EsfApiOptions _options;
        private readonly CompanyOptions _companyOptions;
        private readonly IEsfCredentialManager _esfApiCredentialManager;

        public EsfApiSessionFactory(IOptions<EsfApiOptions> options,
            IOptions<CompanyOptions> companyOptions,
            IEsfCredentialManager esfApiCredentialManager)
        {
            _options = options.Value;
            _companyOptions = companyOptions.Value;
            _esfApiCredentialManager = esfApiCredentialManager;
        }

        private EsfAuthUserCredential _credential;

        private async Task<EsfAuthUserCredential> GetEsfCredentialAsync(Guid? userId, CancellationToken cancellationToken)
        {
            if (_credential == null)
            {
                _credential = await _esfApiCredentialManager.GetEsfCredentialAsync(userId, cancellationToken);
            }
            return _credential;
        }

        public async Task<IEsfApiSession> CreateSessionAsync(CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(null, cancellationToken);
            return await CreateSession(credential);
        }

        public async Task<IEsfApiSessionService> CreateSessionServiceAsync(CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(null, cancellationToken);
            return new EsfApiSessionService(_options, _companyOptions, credential);
        }

        public async Task<IEsfApiSession> CreateUserSessionAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(userId, cancellationToken);
            return await CreateSession(credential);
        }

        public async Task<IEsfApiSessionService> CreateUserSessionServiceAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(userId, cancellationToken);
            return new EsfApiSessionService(_options, _companyOptions, credential);
        }

        #region Private

        private async Task<IEsfApiSession> CreateSession(EsfAuthUserCredential credential)
        {
            var sessionService = new EsfApiSessionService(_options, _companyOptions, credential);
            var session = new EsfApiSession(sessionService);
            await session.CreateSessionAsync();
            return session;
        }

        #endregion
    }
}
