using System;

namespace TCO.Finportal.Shared.Entities
{
    public class EsfUserProfile
    {
        public Guid UserId { get; set; }

        public string UsernameSecretName { get; set; }

        public string PasswordSecretName { get; set; }

        public string Base64AuthCertificateSecretName { get; set; }

        public string Base64SignCertificateSecretName { get; set; }

        public string SignRSAKeyName { get; set; }

        public bool ReadyForAuth()
        {
            return
                !string.IsNullOrEmpty(UsernameSecretName) &&
                !string.IsNullOrEmpty(PasswordSecretName) &&
                !string.IsNullOrEmpty(Base64AuthCertificateSecretName);
        }

        public bool ReadyForSign()
        {
            return
                ReadyForAuth() &&
                !string.IsNullOrEmpty(Base64SignCertificateSecretName) &&
                !string.IsNullOrEmpty(SignRSAKeyName);
        }

        public static EsfUserProfile CreateEmpty(Guid userId) => new EsfUserProfile { UserId = userId };

    }
}
