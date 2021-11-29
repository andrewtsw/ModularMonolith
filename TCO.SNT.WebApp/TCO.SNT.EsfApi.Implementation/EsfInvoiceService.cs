using EsfApiSdk.Invoices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCO.SNT.Common.Extensions;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces.Invoices;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfIntegration.Shared.Extensions;

namespace TCO.SNT.EsfApi.Implementation
{
    internal class EsfInvoiceService : IEsfInvoiceService
    {
        private readonly EsfApiOptions _options;

        public EsfInvoiceService(IOptions<EsfApiOptions> options)
        {
            _options = options.Value;
        }

        private InvoiceServiceClient CreateClient()
        {
            var client = new InvoiceServiceClient(
                 InvoiceServiceClient.EndpointConfiguration.InvoiceServicePort,
                 _options.GetInvoiceWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<InvoiceUpdatesDto> GetAllUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastInvoiceId,
            InvoiceDirection direction, bool fullInfoOnStatusChange)
        {
            lastEventDateUtc.EnsureUtcKind();

            var client = CreateClient();
            bool hasMoreData;
            var updates = new List<InvoiceInfo>();
            do
            {
                var request = new QueryInvoiceUpdateRequest
                {
                    lastEventDate = lastEventDateUtc,
                    lastInvoiceId = lastInvoiceId,
                    lastInvoiceIdSpecified = lastInvoiceId > 0,
                    limit = _options.InvoiceUpdatesLimit,
                    limitSpecified = _options.InvoiceUpdatesLimit > 0,
                    sessionId = sessionId.Value,
                    direction = direction,
                    fullInfoOnStatusChange = fullInfoOnStatusChange
                };

                var responseWrapper = await client.queryUpdatesAsync(new queryUpdates(request));
                var response = responseWrapper.queryUpdatesResponse1;
                hasMoreData = !response.lastBlock;
                lastInvoiceId = response.lastInvoiceIdSpecified ? response.lastInvoiceId : 0;
                lastEventDateUtc = response.lastEventDate.ToUniversalTime();
                updates.AddRange(response.invoiceInfoList);
            }
            while (hasMoreData);

            return new InvoiceUpdatesDto
            {
                LastInvoiceId = lastInvoiceId,
                LastEventDateUtc = lastEventDateUtc,
                Updates = updates,
                IsLastBlock = true
            };
        }

        public async Task<InvoiceUpdatesDto> GetUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastInvoiceId,
            InvoiceDirection direction, bool fullInfoOnStatusChange)
        {
            lastEventDateUtc.EnsureUtcKind();

            var client = CreateClient();

            var request = new QueryInvoiceUpdateRequest
            {
                lastEventDate = lastEventDateUtc,
                lastInvoiceId = lastInvoiceId,
                lastInvoiceIdSpecified = lastInvoiceId > 0,
                limit = _options.InvoiceUpdatesLimit,
                limitSpecified = _options.InvoiceUpdatesLimit > 0,
                sessionId = sessionId.Value,
                direction = direction,
                fullInfoOnStatusChange = fullInfoOnStatusChange
            };

            var responseWrapper = await client.queryUpdatesAsync(new queryUpdates(request));
            var response = responseWrapper.queryUpdatesResponse1;
            lastInvoiceId = response.lastInvoiceIdSpecified ? response.lastInvoiceId : 0;
            lastEventDateUtc = response.lastEventDate.ToUniversalTime();

            return new InvoiceUpdatesDto
            {
                LastInvoiceId = lastInvoiceId,
                LastEventDateUtc = lastEventDateUtc,
                Updates = response.invoiceInfoList,
                IsLastBlock = response.lastBlock
            };
        }

        public async Task<InvoiceInfo> GetInvoiceByIdAsync(EsfApiSessionId sessionId, long id)
        {
            var request = new InvoiceByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new [] { id }
            };

            var client = CreateClient();
            var response = await client.queryInvoiceByIdAsync(new queryInvoiceById(request));
            return response.queryInvoiceByIdResponse1.invoiceInfoList.Single();
        }

        public async Task<InvoiceSummary> SetDeliveredStatusAsync(EsfApiSessionId sessionId, long id)
        {
            var request = new InvoiceByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new [] { id }
            };

            var client = CreateClient();
            var response = await client.confirmInvoiceByIdAsync(new confirmInvoiceById(request));
            return response.confirmInvoiceByIdResponse1.invoiceSummaryList.Single();
        }
    }
}
