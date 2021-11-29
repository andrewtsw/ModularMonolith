using Chevron.Identity.AspNet.Client;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TCO.Einvoicing.Jde.Interfaces;
using TCO.Einvoicing.Jde.Interfaces.Models;

namespace TCO.Einvoicing.Jde.Implementation
{
    public class JdeApimService : IJdeApimService
    {
        private readonly JdeApimOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AzureADOptions _azureADOptions;

        public JdeApimService(
            IHttpClientFactory httpClientFactory,
            IOptions<JdeApimOptions> options,
            IOptions<AzureADOptions> azureADOptions)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
            _azureADOptions = azureADOptions.Value;
        }

        public async Task<AccountReceivablesDto> GetJdeArInvoicesAsync(DateTimeOffset dateUpdated, string nextPageToken, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = TimeSpan.FromMinutes(_options.JdeArRequestTimeout);

            var token = await AcquireTokenAsync(_options.AccountsReceivableScope, cancellationToken);

            var qb = new QueryBuilder();
            qb.Add("sourceEnvironment", _options.SourceEnvironment);
            qb.Add("sourceInstance", _options.SourceInstance);
            qb.Add("dateUpdated", $"{dateUpdated:MMddyyyy}");
            qb.Add("company", _options.Company);

            if (!string.IsNullOrWhiteSpace(nextPageToken))
            {
                qb.Add("pageToken", nextPageToken);
            }

            var uri = new Uri($"{_options.BaseUrl}{qb.ToQueryString().Value}");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = uri,
                Headers =
                {
                    {"Ocp-Apim-Subscription-Key", _options.SubscriptionKey },
                    {"Authorization", $"Bearer {token}" },
                }
            };

            var response = await httpClient.SendAsync(request, cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"[GetJdeArInvoices] AbsoluteUri: {uri.AbsoluteUri}. StatusCode: {response.StatusCode}. Response string: {responseString}");
            }

            return JsonSerializer.Deserialize<AccountReceivablesDto>(responseString);
        }

        private async Task<string> AcquireTokenAsync(string scope, CancellationToken cancellationToken)
        {
            var _app = ConfidentialClientApplicationBuilder.Create(_azureADOptions.ClientId)
                                          .WithClientSecret(_azureADOptions.ClientSecret)
                                          .WithAuthority(AzureCloudInstance.AzurePublic, Guid.Parse(_azureADOptions.TenantId))
                                          .Build();

            var acquireTokenResult = await _app.AcquireTokenForClient(new string[] { scope }).ExecuteAsync(cancellationToken);

            return acquireTokenResult.AccessToken;
        }
    }
}
