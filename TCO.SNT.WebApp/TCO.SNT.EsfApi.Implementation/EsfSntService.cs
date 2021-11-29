using EsfApiSdk.Snt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using TCO.SNT.Common.Extensions;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.Snt;
using TCO.SNT.EsfIntegration.Shared.Extensions;

namespace TCO.SNT.EsfApi.Implementation
{
    internal class EsfSntService : IEsfSntService
    {
        private readonly EsfApiOptions _options;

        public EsfSntService(IOptions<EsfApiOptions> options)
        {
            _options = options.Value;
        }

        private SntWebServiceClient CreateClient()
        {
            var client = new SntWebServiceClient(
             SntWebServiceClient.EndpointConfiguration.SntWebServicePort,
             _options.GetSntWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<SntUpdatesDto> GetUpdatesAsync(EsfApiSessionId sessionId,
            DateTime lastEventDateUtc,
            long lastSntId)
        {
            lastEventDateUtc.EnsureUtcKind();

            var client = CreateClient();
            bool hasMoreData;
            var updates = new List<SntInfo>();
            do
            {
                var request = new SntQueryUpdatesRequest
                {
                    lastEventDate = lastEventDateUtc,
                    lastSntId = lastSntId,
                    lastSntIdSpecified = lastSntId > 0,
                    limit = _options.SntUpdatesLimit,
                    limitSpecified = _options.SntUpdatesLimit > 0,
                    sessionId = sessionId.Value
                };

                var responseWrapper = await client.queryUpdateAsync(new queryUpdate(request));
                var response = responseWrapper.sntQueryUpdatesResponse;
                hasMoreData = !response.lastBlock;
                lastSntId = response.lastSntIdSpecified ? response.lastSntId : 0;
                lastEventDateUtc = response.lastEventDate.ToUniversalTime();
                updates.AddRange(response.sntInfoList);
            }
            while (hasMoreData);

            return new SntUpdatesDto
            {
                LastSntId = lastSntId,
                LastEventDateUtc = lastEventDateUtc,
                Updates = updates
            };
        }

        public async Task<UploadSntResponse> UploadSntAsync(EsfApiSessionId sessionId, DigitalSignatureInfo signatureInfo)
        {
            var request = new UploadSntRequest
            {
                sessionId = sessionId.Value,
                x509Certificate = signatureInfo.Certificate,
                sntInfoList = new[]
                {
                    new SntUploadInfo
                    {
                        sntBody = signatureInfo.Body,
                        version = SntVersion.SntV1,
                        signature = signatureInfo.Signature,
                        signatureType = SignatureType.OPERATOR
                    }
                }
            };

            var client = CreateClient();
            var response = await client.uploadSntAsync(new uploadSnt(request));
            return response.sntUploadResponse;
        }

        public async Task<SntInfo> GetSntAsync(EsfApiSessionId sessionId, long sntId)
        {
            var request = new SntQueryByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { sntId }
            };

            var client = CreateClient();
            var response = await client.querySntByIdAsync(new querySntById(request));
            return response.sntQueryByIdResponse.sntInfoList.Single();
        }

        public async Task<SntError> GetSntErrorsAsync(EsfApiSessionId sessionId, long sntId)
        {
            var request = new SntQueryByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { sntId }
            };

            var client = CreateClient();
            var response = await client.querySntErrorByIdAsync(new querySntErrorById(request));
            return response.sntQueryErrorByIdResponse.sntErrorList
                .SingleOrDefault(x => x.sntId == sntId);
        }

        public async Task<SntHistoryInfo> GetSntHistoryAsync(EsfApiSessionId sessionId, long sntId)
        {
            var request = new SntHistoryQueryByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { sntId }
            };

            var client = CreateClient();
            var response = await client.querySntHistoryByIdAsync(new querySntHistoryById(request));
            return response.sntHistoryQueryByIdResponse.resultList.Single();
        }

        public async Task<SntSummary> GetSntStatusAsync(EsfApiSessionId sessionId, long sntId)
        {
            var request = new SntQueryByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { sntId }
            };

            var client = CreateClient();
            var response = await client.querySntStatusByIdAsync(new querySntStatusById(request));
            return response.sntQueryStatusByIdResponse.sntSummaryList.Single();
        }

        public async Task<SntChangeStatusResult> GetSntViewAsync(EsfApiSessionId sessionId, long sntId)
        {
            var request = new SntQueryByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { sntId }
            };

            var client = CreateClient();
            var response = await client.queryViewSntAsync(new queryViewSnt(request));
            return response.sntViewResponse.resultList.Single();
        }

        public async Task<SntChangeStatusResult> ChangeStatusAsync(EsfApiSessionId sessionId, long sntId, DigitalSignatureInfo signatureInfo)
        {
            var sntActionInfo = new SntActionInfo
            {
                sntActionBody = signatureInfo.Body,
                sntId = sntId,
                certificate = signatureInfo.Certificate,
                signature = signatureInfo.Signature,
                signatureType = SignatureType.OPERATOR,
                sntVersion = SntVersion.SntV1,
            };

            var request = new SntChangeStatusRequest
            {
                sntActionInfoList = new SntActionInfo[] { sntActionInfo },
                sessionId = sessionId.Value
            };

            var client = CreateClient();
            var response = await client.changeStatusAsync(new changeStatus(request));
            return response.sntChangeStatusResponse.resultList.Single();
        }
    }
}
