using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using TCO.SNT.Common.Extensions;
using TCO.SNT.EsfIntegration.Shared.Extensions;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;
using VsSdk.UForm;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreUFormService : IVstoreUFormService
    {
        private const string UFormV1 = "UFormV1";

        private readonly VStoreOptions _options;

        public VstoreUFormService(IOptions<VStoreOptions> options)
        {
            _options = options.Value;
        }

        private UFormWebServiceClient CreateClient()
        {
            var client = new UFormWebServiceClient(
                UFormWebServiceClient.EndpointConfiguration.UFormWebServicePort,
                _options.GetUFormsWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<uploadUFormResponse1> UploadUFormAsync(VstoreSessionId sessionId, DigitalSignatureInfo signatureInfo)
        {
            var request = new UploadUFormRequest
            {
                sessionId = sessionId.Value,
                x509Certificate = signatureInfo.Certificate,
                uFormInfoList = new[] { new UFormUploadInfo
                {
                    signature = signatureInfo.Signature,
                    // This signatureType used for manually created forms in ESF. So we use the same signatureType
                    signatureType = SignatureType.OPERATOR,
                    // The is a single version for now
                    version = UFormV1,
                    // uFormBodyRaw is a custom property for CDATA xml serialization.
                    uFormBodyRaw = signatureInfo.Body
                } }
            };

            var client = CreateClient();
            var response = await client.uploadUFormAsync(new uploadUForm(request));
            return response;
        }

        public async Task<UFormUpdatesDto> GetUpdatesAsync(VstoreSessionId sessionId, DateTime lastEventDateUtc)
        {
            lastEventDateUtc.EnsureUtcKind();

            var client = CreateClient();
            bool hasMoreData;
            var updates = new List<UFormInfo>();

            // Workaround about lastUFormId. We can not pass lastUFormId from the prev response 
            // because in this case queryUpdatesAsync endpoint returns not all data.
            // So we always send 1 as a lastUFormId
            do
            {
                var request = new UFormQueryUpdatesRequest
                {
                    sessionId = sessionId.Value,
                    limit = _options.UFormUpdatesLimit,
                    limitSpecified = _options.UFormUpdatesLimit > 0,
                    lastUFormIdSpecified = true,
                    lastUFormId = 1L,
                    lastEventDate = lastEventDateUtc
                };

                var responseWrapper = await client.queryUpdatesAsync(new queryUpdates(request));
                var response = responseWrapper.uFormQueryUpdatesResponse;
                hasMoreData = !response.lastBlock;
                lastEventDateUtc = response.lastEventDate.ToUniversalTime();
                updates.AddRange(response.uFormInfoList);
            }
            while (hasMoreData);

            return new UFormUpdatesDto
            {
                LastEventDateUtc = lastEventDateUtc,
                Updates = updates
            };
        }

        public async Task<UFormInfo> GetUFormAsync(VstoreSessionId sessionId, long id)
        {
            var client = CreateClient();

            // ESF API does not work correctly for this method.
            // It allows passing multiple ids. 
            // But it works correctly only for the single id.
            var request = new UFormByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { id }
            };

            var response = await client.queryUFormByIdAsync(new queryUFormById(request));
            return response.queryUFormByIdResponse1.uFormInfoList.Single();
        }

        public async Task<UFormErrorInfo> GetUFormErrorsAsync(VstoreSessionId sessionId, long id)
        {
            var client = CreateClient();
            var request = new UFormErrorByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { id }
            };

            var response = await client.queryUFormErrorByIdAsync(new queryUFormErrorById(request));
            return response.uFormErrorByIdResponse.uFormErrorInfoList.SingleOrDefault();
        }

        public async Task<UFormSummary> GetUFormStatusAsync(VstoreSessionId sessionId, long id)
        {
            var client = CreateClient();
            var request = new UFormByIdRequest
            {
                sessionId = sessionId.Value,
                idList = new[] { id }
            };

            var response = await client.queryUFormStatusByIdAsync(new queryUFormStatusById(request));
            return response.queryUFormStatusByIdResponse1.uFormSummaryList.Single();
        }
    }
}
