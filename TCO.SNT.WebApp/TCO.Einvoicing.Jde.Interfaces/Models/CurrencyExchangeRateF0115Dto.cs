using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class CurrencyExchangeRateF0115Dto
    {
        [JsonPropertyName("currencyCodeFrom")]
        public string CurrencyCodeFrom { get; set; }

        [JsonPropertyName("toCurrency")]
        public string ToCurrency { get; set; }

        [JsonPropertyName("exchangeRateEffectiveDate")]
        public string ExchangeRateEffectiveDate { get; set; }

        [JsonPropertyName("currencyConversionRate")]
        public string CurrencyConversionRate { get; set; }
    }

}
