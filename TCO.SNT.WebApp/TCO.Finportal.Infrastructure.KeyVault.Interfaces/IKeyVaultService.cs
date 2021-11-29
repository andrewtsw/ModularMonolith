using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.Finportal.Infrastructure.KeyVault.Interfaces
{
    public interface IKeyVaultService
    {
        Task ImportKeyAsync(string name, RSA rsa, CancellationToken cancellationToken);

        Task<string> SignAsync(string keyName, string value, CancellationToken cancellationToken);

        Task<string> GetSecretAsync(string name, CancellationToken cancellationToken);

        Task SetSecretAsync(string name, string value, CancellationToken cancellationToken);

        Task EncryptSecretAsync(string name, string value, CancellationToken cancellationToken);

        Task<string> DecryptSecretAsync(string name, CancellationToken cancellationToken);
    }
}
