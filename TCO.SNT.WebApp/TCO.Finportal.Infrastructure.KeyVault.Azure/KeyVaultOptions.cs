using System;

namespace TCO.Finportal.Infrastructure.KeyVault.Azure
{
    public class KeyVaultOptions
    {
        public Uri Uri { get; set; }

        public string PasswordEncryptionKey { get; set; }
    }
}
