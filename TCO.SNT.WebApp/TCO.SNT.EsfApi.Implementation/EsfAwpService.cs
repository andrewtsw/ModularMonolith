using EsfApiSdk.Awp;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCO.SNT.Common.Extensions;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces.Awp;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfIntegration.Shared.Extensions;

namespace TCO.SNT.EsfApi.Implementation
{
    internal class EsfAwpService : IEsfAwpService
    {
        private readonly EsfApiOptions _options;

        public EsfAwpService(IOptions<EsfApiOptions> options)
        {
            _options = options.Value;
        }

        private AwpWebServiceClient CreateClient()
        {
            var client = new AwpWebServiceClient(AwpWebServiceClient.EndpointConfiguration.AwpWebServicePort, _options.GetAwpWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<AwpUpdatesDto> GetUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastAwpId)
        {
            lastEventDateUtc.EnsureUtcKind();

            var client = CreateClient();
            var updates = new List<AwpInfo>();

            var request = new AwpQueryUpdatesRequest
            {
                lastEventDate = lastEventDateUtc,
                lastAwpId = lastAwpId,
                limit = _options.AwpUpdatesLimit,
                limitSpecified = _options.AwpUpdatesLimit > 0,
                sessionId = sessionId.Value
            };

            var responseWrapper = await client.queryUpdateAsync(request);
            var response = responseWrapper.awpQueryUpdatesResponse;
            lastAwpId = response.lastAwpIdSpecified ? response.lastAwpId : 0L;
            lastEventDateUtc = response.lastEventDate.ToUniversalTime();
            updates.AddRange(response.awpInfoList);

            return new AwpUpdatesDto
            {
                LastAwpId = lastAwpId,
                LastEventDateUtc = lastEventDateUtc,
                Updates = updates
            };
        }

        public async Task<AwpUpdatesDto> GetAllUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastAwpId)
        {
            lastEventDateUtc.EnsureUtcKind();

            var client = CreateClient();
            var updates = new List<AwpInfo>();

            bool hasMoreData = true;
            while (hasMoreData)
            {
                var request = new AwpQueryUpdatesRequest
                {
                    lastEventDate = lastEventDateUtc,
                    lastAwpId = lastAwpId,
                    limit = _options.AwpUpdatesLimit,
                    limitSpecified = _options.AwpUpdatesLimit > 0,
                    sessionId = sessionId.Value
                };

                var responseWrapper = await client.queryUpdateAsync(request);
                var response = responseWrapper.awpQueryUpdatesResponse;
                lastAwpId = response.lastAwpIdSpecified ? response.lastAwpId : 0L;
                lastEventDateUtc = response.lastEventDate.ToUniversalTime();
                updates.AddRange(response.awpInfoList);
                hasMoreData = response.awpInfoList.Any();
            }

            return new AwpUpdatesDto
            {
                LastAwpId = lastAwpId,
                LastEventDateUtc = lastEventDateUtc,
                Updates = updates
            };
        }
    }
}
