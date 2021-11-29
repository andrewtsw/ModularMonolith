namespace TCO.SNT.ExchangeRates.NationalBankKz
{
    public class ExchangeRatesOptions
    {
        /// <summary>
        /// https://nationalbank.kz/rss/get_rates.cfm?fdate={0:dd.MM.yyyy}
        /// </summary>
        public string UriTemplate { get; set; }
    }
}
