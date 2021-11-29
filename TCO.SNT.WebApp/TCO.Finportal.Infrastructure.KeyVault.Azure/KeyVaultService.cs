using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.KeyVault.Interfaces;

namespace TCO.Finportal.Infrastructure.KeyVault.Azure
{
    internal class KeyVaultService : IKeyVaultService
    {
        private static readonly EncryptionAlgorithm EncryptionAlgorithm = EncryptionAlgorithm.RsaOaep256;
        private static readonly Encoding EncryptionEncoding = Encoding.Unicode;

        private readonly KeyVaultOptions _keyVaultOptions;

        public KeyVaultService(IOptions<KeyVaultOptions> options)
        {
            _keyVaultOptions = options.Value;
        }

        public async Task ImportKeyAsync(string name, RSA rsa, CancellationToken cancellationToken)
        {
            var keyClient = GetKeyClient(CreateCredential());
            await keyClient.ImportKeyAsync(name,
                            new JsonWebKey(rsa, includePrivateParameters: true, new[] { KeyOperation.Sign }),
                            cancellationToken);
        }

        public async Task<string> SignAsync(string keyName, string value, CancellationToken cancellationToken)
        {
            var credential = CreateCredential();
            var cryptoClient = await CreateCryptographyClientAsync(keyName, credential, cancellationToken);
            var data = Encoding.UTF8.GetBytes(value);
            var response = await cryptoClient.SignDataAsync(SignatureAlgorithm.RS256, data, cancellationToken);
            return Convert.ToBase64String(response.Signature);
        }

        public Task SetSecretAsync(string name, string value, CancellationToken cancellationToken)
        {
            return SetSecretAsync(name, value, CreateCredential(), cancellationToken);
        }

        public Task<string> GetSecretAsync(string name, CancellationToken cancellationToken)
        {
            return GetSecretAsync(name, CreateCredential(), cancellationToken);
        }

        public async Task EncryptSecretAsync(string name, string value, CancellationToken cancellationToken)
        {
            var credential = CreateCredential();
            var cryptoClient = await CreateCryptographyClientAsync(_keyVaultOptions.PasswordEncryptionKey,
                credential, cancellationToken);
            var plaintextBytes = EncryptionEncoding.GetBytes(value);
            var decryptResult = await cryptoClient.EncryptAsync(EncryptionAlgorithm, plaintextBytes, cancellationToken);

            var base64Ciphertext = Convert.ToBase64String(decryptResult.Ciphertext);
            await SetSecretAsync(name, base64Ciphertext, credential, cancellationToken);
        }

        public async Task<string> DecryptSecretAsync(string name, CancellationToken cancellationToken)
        {
            var credential = CreateCredential();
            var base64Ciphertext = await GetSecretAsync(name, credential, cancellationToken);

            var cryptoClient = await CreateCryptographyClientAsync(_keyVaultOptions.PasswordEncryptionKey,
                credential, cancellationToken);
            var ciphertext = Convert.FromBase64String(base64Ciphertext);
            var decryptResult = await cryptoClient.DecryptAsync(EncryptionAlgorithm, ciphertext, cancellationToken);

            return EncryptionEncoding.GetString(decryptResult.Plaintext);
        }

        #region Private

        private SecretClient GetSecretClient(TokenCredential credential) => new SecretClient(_keyVaultOptions.Uri, credential);

        private KeyClient GetKeyClient(TokenCredential credential) => new KeyClient(_keyVaultOptions.Uri, credential);

        private TokenCredential CreateCredential() => new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ExcludeAzureCliCredential = true,
            ExcludeInteractiveBrowserCredential = true,
            ExcludeVisualStudioCodeCredential = true,
            ExcludeVisualStudioCredential = true,
        });

        private async Task SetSecretAsync(string name, string value, TokenCredential credential,
            CancellationToken cancellationToken)
        {
            var secretClient = GetSecretClient(credential);
            await secretClient.SetSecretAsync(name, value, cancellationToken);
        }

        private async Task<string> GetSecretAsync(string name, TokenCredential credential,
            CancellationToken cancellationToken)
        {
            var secretClient = GetSecretClient(credential);
            var response = await secretClient.GetSecretAsync(name, cancellationToken: cancellationToken);
            return response.Value.Value;
        }

        private async Task<CryptographyClient> CreateCryptographyClientAsync(string keyName,
            TokenCredential credential, CancellationToken cancellationToken)
        {
            var keyClient = GetKeyClient(credential);
            var getKeyResponse = await keyClient.GetKeyAsync(keyName, cancellationToken: cancellationToken);

            return new CryptographyClient(getKeyResponse.Value.Id, credential);
        }

        #endregion
    }
}
