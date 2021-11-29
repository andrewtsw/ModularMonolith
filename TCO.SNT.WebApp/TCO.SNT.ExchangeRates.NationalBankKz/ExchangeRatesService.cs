using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Serialization;
using TCO.SNT.ExchangeRates.Interfaces;

namespace TCO.SNT.ExchangeRates.NationalBankKz
{
    internal class ExchangeRatesService : IExchangeRatesService
    {
        private readonly ExchangeRatesOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;

        public ExchangeRatesService(IOptions<ExchangeRatesOptions> options, IHttpClientFactory httpClientFactory)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IReadOnlyList<CurrencyRate>> GetRatesAsync(DateTime date, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var uri = string.Format(_options.UriTemplate, date);
            var response = await httpClient.GetAsync(uri, cancellationToken);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            var root = SerializationHelper.DeserializeFromXml<RootElement>(stream);

            return root.Rates;

        }

    }
}
