using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class AccountReceivableInvoiceDto
    {
        [JsonPropertyName("accountReceivablesF03B11")]
        public AccountReceivablesF03B11Dto AccountReceivablesF03B11 { get; set; }

        [JsonPropertyName("generalLedger")]
        public GeneralLedgerDto GeneralLedger { get; set; }

        [JsonPropertyName("addressBook")]
        public AddressBookDto AddressBook { get; set; }

        [JsonPropertyName("taxRate1")]
        public string TaxRate1 { get; set; }

        [JsonPropertyName("currencyExchangeRateF0115")]
        public CurrencyExchangeRateF0115Dto CurrencyExchangeRateF0115 { get; set; }

        [JsonPropertyName("getUOM")]
        public GetUomDto GetUOM { get; set; }

        public string GetDocumentNumber()
        {
            return AccountReceivablesF03B11?.DocumentNumber;
        }

        public string GetDocumentType()
        {
            return AccountReceivablesF03B11?.DocumentType;
        }

        public string GetDocumentPayItem()
        {
            return AccountReceivablesF03B11?.DocumentPayItem;
        }
    }

}
