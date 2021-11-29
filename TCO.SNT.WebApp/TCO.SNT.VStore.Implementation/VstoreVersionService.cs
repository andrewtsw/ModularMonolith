using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;
using TCO.SNT.EsfIntegration.Shared.Extensions;
using VsSdk.Version;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreVersionService : IVstoreVersionService
    {
        private readonly VStoreOptions _options;

        public VstoreVersionService(IOptions<VStoreOptions> options)
        {
            _options = options.Value;
        }

        private VstoreVersionServiceClient CreateClient()
        {
            var client = new VstoreVersionServiceClient(
                VstoreVersionServiceClient.EndpointConfiguration.VstoreVersionServicePort,
                _options.GetVersionWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<errorDescription[]> GetErrorCodesAsync(Language language)
        {
            var client = CreateClient();

            var request = new errorCodesRequest
            {
                language = language.ToString()
            };
            var response = await client.getErrorCodesAsync(new getErrorCodes(request));

            return response.errorCodesResponse.errorDescriptions;
        }

        public async Task<string> GetVersionAsync()
        {
            var client = CreateClient();
            var response = await client.getVersionAsync(new getVersion());
            return response.versionResponse.version;
        }

        public async Task<string> GetApiVersionAsync()
        {
            var client = CreateClient();
            var response = await client.getApiVersionAsync(new getApiVersion());
            return response.apiVersionResponse.version;
        }

        public async Task<string> GetUFormVersionAsync()
        {
            var client = CreateClient();
            var response = await client.getUFormVersionAsync(new getUFormVersion());
            return response.uFormVersionResponse.version;
        }
    }
}
