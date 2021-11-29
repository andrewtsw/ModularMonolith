using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.KeyVault.Interfaces;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.SNT.EsfIntegration.Shared.Credential;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Shared.ContractImplementation
{
    internal class EsfCredentialManager : IEsfCredentialManager
    {
        private readonly ISharedDbContext _sharedDbContext;
        private readonly IKeyVaultService _keyVaultService;
        private readonly ICurrentUserService _currentUserService;

        public EsfCredentialManager(ISharedDbContext sharedDbContext,
            IKeyVaultService keyVaultService,
            ICurrentUserService currentUserService)
        {
            _sharedDbContext = sharedDbContext;
            _keyVaultService = keyVaultService;
            _currentUserService = currentUserService;
        }

        public async Task<EsfAuthUserCredential> GetEsfCredentialAsync(Guid? userId, CancellationToken cancellationToken)
        {
            var profile = await _sharedDbContext.GetAuthEsfUserProfileAsync(userId ?? _currentUserService.UserId, cancellationToken);

            var username = await _keyVaultService.GetSecretAsync(profile.UsernameSecretName, cancellationToken);
            var password = await _keyVaultService.DecryptSecretAsync(profile.PasswordSecretName, cancellationToken);
            var authCertificate = await _keyVaultService.GetSecretAsync(profile.Base64AuthCertificateSecretName, cancellationToken);

            return new EsfAuthUserCredential(username, password, authCertificate);
        }
    }
}
