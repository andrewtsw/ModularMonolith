using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.EsfIntegration.Shared.Credential;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreSessionFactory : IVstoreSessionFactory
    {
        private readonly VStoreOptions _options;
        private readonly CompanyOptions _companyOptions;
        private readonly IEsfCredentialManager _esfApiCredentialManager;

        public VstoreSessionFactory(IOptions<VStoreOptions> options,
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

        public async Task<IVstoreSession> CreateSessionAsync(CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(null, cancellationToken);
            return await CreateSession(credential);
        }

        public async Task<IVstoreSessionService> CreateSessionServiceAsync(CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(null, cancellationToken);
            return new VstoreSessionService(_options, _companyOptions, credential);
        }

        public async Task<IVstoreSession> CreateUserSessionAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(userId, cancellationToken);
            return await CreateSession(credential);
        }

        public async Task<IVstoreSessionService> CreateUserSessionServiceAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var credential = await GetEsfCredentialAsync(userId, cancellationToken);
            return new VstoreSessionService(_options, _companyOptions, credential);
        }

        #region Private

        private async Task<IVstoreSession> CreateSession(EsfAuthUserCredential credential)
        {
            var sessionService = new VstoreSessionService(_options, _companyOptions, credential);
            var session = new VstoreSession(sessionService);
            await session.CreateSessionAsync();
            return session;
        }

        #endregion
    }
}
