using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace TCO.SNT.EsfIntegration.Shared.Extensions
{
    public static class ClientCredentialsExtensions
    {
        public static void EnsureCertificateValidationEnabled(this ClientCredentials clientCredentials,
            bool certificateValidationEnabled)
        {
            if (!certificateValidationEnabled)
            {
                clientCredentials.ServiceCertificate.SslCertificateAuthentication =
                    new X509ServiceCertificateAuthentication
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    };
            }
        }
    }
}
