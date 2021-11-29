using System;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.SNT.EsfIntegration.Shared.Credential
{
    public interface IEsfCredentialManager
    {
        Task<EsfAuthUserCredential> GetEsfCredentialAsync(Guid? userId, CancellationToken cancellationToken);
    }
}
