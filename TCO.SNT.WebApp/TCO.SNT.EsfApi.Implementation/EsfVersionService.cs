using EsfApiSdk.Version;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces;
using TCO.SNT.EsfIntegration.Shared.Extensions;

namespace TCO.SNT.EsfApi.Implementation
{
    internal class EsfVersionService : IEsfVersionService
    {
        private readonly EsfApiOptions _options;

        public EsfVersionService(IOptions<EsfApiOptions> options)
        {
            _options = options.Value;
        }

        private VersionServiceClient CreateClient()
        {
            var client = new VersionServiceClient(
                VersionServiceClient.EndpointConfiguration.VersionServicePort,
                _options.GetVersionWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            return client;
        }

        public async Task<string> GetApiVersionAsync()
        {
            var client = CreateClient();
            var response = await client.getApiVersionAsync(new getApiVersion());
            return response.apiVersionResponse.version;
        }

        public async Task<errorDescription[]> GetErrorCodesAsync(Language language)
        {
            var client = CreateClient();
            var response = await client.getErrorCodesAsync(new getErrorCodes(new errorCodesRequest 
            { 
                language = language.ToString()
            }));
            return response.errorCodesResponse.errorDescriptions;
        }

        public async Task<string> GetEsfVersionAsync()
        {
            var client = CreateClient();
            var response = await client.getEsfVersionAsync(new getEsfVersion());
            return response.esfVersionResponse.version;
        }

        public async Task<string> GetVersionAsync()
        {
            var client = CreateClient();
            var response = await client.getVersionAsync(new getVersion());
            return response.versionResponse.version;
        }
    }
}
