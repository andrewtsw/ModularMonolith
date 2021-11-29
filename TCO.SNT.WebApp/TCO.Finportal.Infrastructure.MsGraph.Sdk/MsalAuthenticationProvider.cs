using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TCO.Finportal.Infrastructure.MsGraph.Sdk
{
    internal class MsalAuthenticationProvider : IAuthenticationProvider
    {
        private readonly IConfidentialClientApplication _clientApplication;
        private readonly string[] _scopes;

        public MsalAuthenticationProvider(IConfidentialClientApplication clientApplication, string[] scopes)
        {
            _clientApplication = clientApplication;
            _scopes = scopes;
        }

        /// <summary>
        /// Update HttpRequestMessage with credentials
        /// </summary>
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var token = await GetTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
        }

        /// <summary>
        /// Acquire Token 
        /// </summary>
        public async Task<string> GetTokenAsync()
        {
            var authResult = await _clientApplication
                                    .AcquireTokenForClient(_scopes)
                                    .ExecuteAsync();

            return authResult.AccessToken;
        }
    }
}
