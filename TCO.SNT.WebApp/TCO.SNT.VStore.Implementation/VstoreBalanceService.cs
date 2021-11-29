using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCO.SNT.EsfIntegration.Shared.Extensions;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;
using VsSdk.VstoreBalance;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreBalanceService : IVstoreBalanceService
    {
        private readonly VStoreOptions _options;

        public VstoreBalanceService(IOptions<VStoreOptions> options)
        {
            _options = options.Value;
        }

        private VstoreBalanceWebServiceClient CreateClient()
        {
            var client = new VstoreBalanceWebServiceClient(
                VstoreBalanceWebServiceClient.EndpointConfiguration.VstoreBalanceWebServicePort,
                _options.GetBalanceWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<IReadOnlyList<Balance>> GetCurrentStatusAsync(VstoreSessionId sessionId)
        {
            var client = CreateClient();
            bool hasMoreData;
            long lastBalanceId = 0L;
            var balances = new List<Balance>();
            do
            {
                var request = new BalanceQueryCurrentStatusRequest
                {
                    sessionId = sessionId.Value,
                    limit = _options.BalanceCurrentStatusLimit,
                    lastBalanceIdSpecified = lastBalanceId > 0,
                    lastBalanceId = lastBalanceId
                };
                var responseWrapper = await client.queryCurrentStatusAsync(new queryCurrentStatus(request));
                var response = responseWrapper.queryCurrentStatusResponse1;
                hasMoreData = !response.lastBlock;
                lastBalanceId = response.lastBalanceIdSpecified ? response.lastBalanceId : 0L;
                balances.AddRange(response.balances);
            }
            while (hasMoreData);

            return balances;
        }
    }
}
