using EsfApiSdk.AwpXsd;
using EsfApiSdk.SntXsd;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using VsSdk.VstoreXsd;

namespace TCO.SNT.XsdImport
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var baseUri = new Uri("https://esf.gov.kz:8443"); // prod
            // var baseUri = new Uri("https://test3.esf.kgd.gov.kz:8443"); // test

            //await ExportUFormXsd(address);
            //await ExportSntXsd(baseUri);
            await ExportAwpXsd(baseUri);
        }

        private static async Task ExportUFormXsd(Uri baseUri)
        {
            var client = new VstoreXsdServiceClient(VstoreXsdServiceClient.EndpointConfiguration.VstoreXsdServicePort,
                new Uri(baseUri, "/esf-web/vstore-ws/api1/VstoreXsdService").ToString());

            // Disable cert validation for test3 because sometimes their cert is invalid
            client.ClientCredentials.EnsureCertificateValidationEnabled(false);

            var UFormXsd = await client.queryUFormXsdAsync(new queryUFormXsd(new QueryUFormXsdRequest { version = "UFormV1" }));
            await SaveAllAsync(Environment.CurrentDirectory, UFormXsd.queryUFormXsdResponse1.xsdList, "UForm");
        }

        private static async Task ExportSntXsd(Uri baseUri)
        {
            var client = new SntXsdServiceClient(SntXsdServiceClient.EndpointConfiguration.SntXsdServicePort,
                new Uri(baseUri, "/esf-web/ws/api1/SntXsdService").ToString());

            // Disable cert validation for test3 because sometimes their cert is invalid
            client.ClientCredentials.EnsureCertificateValidationEnabled(false);

            var SntXsd = await client.querySntXsdAsync(new querySntXsd(new SntXsdRequest { version = "SntV1" }));
            await SaveAllAsync(Environment.CurrentDirectory, SntXsd.querySntXsdResponse1.xsdList, "Snt");
        }

        private static async Task ExportAwpXsd(Uri baseUri)
        {
            var client = new AwpXsdServiceClient(AwpXsdServiceClient.EndpointConfiguration.AwpXsdServicePort,
                new Uri(baseUri, "/esf-web/ws/api1/AwpXsdService").ToString());

            // Disable cert validation for test3 because sometimes their cert is invalid
            client.ClientCredentials.EnsureCertificateValidationEnabled(false);

            var AwpXsd = await client.queryAwpXsdAsync(new AwpXsdRequest { version = awpVersion.AwpV1 });
            await SaveAllAsync(Environment.CurrentDirectory, AwpXsd.queryAwpXsdResponse1.xsdList, "Awp");
        }

        private static async Task SaveAllAsync(string dir, string[] xsdList, string prefix)
        {
            var tasks = xsdList.Select((body, index) => File.WriteAllTextAsync(Path.Combine(dir, $"{prefix}-{index}.xsd"), body));
            await Task.WhenAll(tasks);
        }
    }

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
