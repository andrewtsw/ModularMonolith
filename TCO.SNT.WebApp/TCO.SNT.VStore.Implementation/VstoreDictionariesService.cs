using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCO.SNT.Common.Extensions;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;
using TCO.SNT.EsfIntegration.Shared.Extensions;
using VsSdk.Dictionaries;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreDictionariesService : IVstoreDictionariesService
    {
        private readonly VStoreOptions _options;

        public VstoreDictionariesService(IOptions<VStoreOptions> options)
        {
            _options = options.Value;
        }

        private DictWebServiceClient CreateClient()
        {
            var client = new DictWebServiceClient(
                DictWebServiceClient.EndpointConfiguration.DictWebServicePort,
                _options.GetDictionariesWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<MeasureUnitUpdatesDto> GetMeasureUnitUpdatesAsync(VstoreSessionId sessionId, 
            DateTime lastUpdateDateUtc)
        {
            lastUpdateDateUtc.EnsureUtcKind();

            var client = CreateClient();
            var responseWrapper = await client.queryMeasureUnitUpdatesAsync(new queryMeasureUnitUpdates(new MeasureUnitUpdatesRequest
            {
                sessionId = sessionId.Value,
                lastUpdateDate = lastUpdateDateUtc,
                lastUpdateDateSpecified = true
            }));

            var respose = responseWrapper.measureUtitUpdatesResponse;
            return new MeasureUnitUpdatesDto
            {
                LastUpdateDateUtc = respose.lastUpdateDateSpecified ? respose.lastUpdateDate.ToUniversalTime() : (DateTime?)null,
                Updates = respose.measureUnitList
            };
        }

        public async Task<GsvsUpdatesDto> GetGsvsUpdates(VstoreSessionId sessionId, long lastChangeId)
        {
            var client = CreateClient();

            bool lastBlock;
            var updates = new List<GsvsUpdate>();
            do
            {
                var response = await client.queryGsvsUpdatesAsync(new queryGsvsUpdates(new GsvsUpdatesRequest
                {
                    sessionId = sessionId.Value,
                    blockSize = _options.GetGsvsUpdatesBlockSize,
                    lastChangeId = lastChangeId
                }));
                lastBlock = response.gsvsUpdatesResponse.lastBlock;
                lastChangeId = response.gsvsUpdatesResponse.maxChangeId;
                updates.AddRange(response.gsvsUpdatesResponse.gsvsUpdateList);
            }
            while (!lastBlock);

            return new GsvsUpdatesDto
            {
                Updates = updates,
                LastChangeId = lastChangeId
            };
        }


    }
}
