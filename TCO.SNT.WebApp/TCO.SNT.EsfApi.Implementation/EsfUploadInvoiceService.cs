using EsfApiSdk.UploadInvoice;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.UploadInvoice;
using TCO.SNT.EsfIntegration.Shared.Extensions;

namespace TCO.SNT.EsfApi.Implementation
{
    internal class EsfUploadInvoiceService : IEsfUploadInvoiceService
    {
        private const string InvoiceV2 = "InvoiceV2";

        private readonly EsfApiOptions _options;

        public EsfUploadInvoiceService(IOptions<EsfApiOptions> options)
        {
            _options = options.Value;
        }

        private UploadInvoiceServiceClient CreateClient()
        {
            var client = new UploadInvoiceServiceClient(
                 UploadInvoiceServiceClient.EndpointConfiguration.UploadInvoiceServicePort,
                 _options.GetUploadInvoiceWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<SyncInvoiceResponse> SyncInvoiceAsync(EsfApiSessionId sessionId, DigitalSignatureInfo signatureInfo)
        {
            var request = new SyncInvoiceRequest
            {
                sessionId = sessionId.Value,
                x509Certificate = signatureInfo.Certificate,
                invoiceUploadInfoList = new[]
                {
                    new invoiceUploadInfo
                    {
                        invoiceBody = signatureInfo.Body,
                        version = InvoiceV2,
                        signature = signatureInfo.Signature,
                        signatureType = SignatureType.OPERATOR
                    }
                }
            };

            var client = CreateClient();
            var response = await client.syncInvoiceAsync(request);
            return response.syncInvoiceResponse;
        }
    }
}
