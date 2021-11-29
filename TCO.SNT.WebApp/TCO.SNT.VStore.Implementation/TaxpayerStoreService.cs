using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;
using TCO.SNT.EsfIntegration.Shared.Extensions;
using VsSdk.TaxpayerStore;

namespace TCO.SNT.VStore.Implementation
{
    internal class TaxpayerStoreService : ITaxpayerStoreService
    {
        private readonly VStoreOptions _options;

        public TaxpayerStoreService(IOptions<VStoreOptions> options)
        {
            _options = options.Value;
        }

        private TaxpayerStoreWebServiceClient CreateClient()
        {
            var client = new TaxpayerStoreWebServiceClient(
                TaxpayerStoreWebServiceClient.EndpointConfiguration.TaxpayerStoreWebServicePort,
                _options.GetTaxpayerStoreWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<IReadOnlyList<TaxpayerStore>> GetAllAsync(VstoreSessionId sessionId)
        {
            var client = CreateClient();
            var response = await client.listAsync(new list(new TaxpayerStoreListRequest
            {
                sessionId = sessionId.Value
            }));
            return response.listTaxpayerStoreResponse.taxpayerStoreList;
        }
    }
}
