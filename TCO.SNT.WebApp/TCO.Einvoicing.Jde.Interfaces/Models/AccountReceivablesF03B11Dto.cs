using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class AccountReceivablesF03B11Dto
    {
        [JsonPropertyName("documentNumber")]
        public string DocumentNumber { get; set; }

        [JsonPropertyName("documentType")]
        public string DocumentType { get; set; }

        [JsonPropertyName("documentCompany")]
        public string DocumentCompany { get; set; }

        [JsonPropertyName("documentPayItem")]
        public string DocumentPayItem { get; set; }

        [JsonPropertyName("addressNumber")]
        public string AddressNumber { get; set; }

        [JsonPropertyName("invoiceDate")]
        public string InvoiceDate { get; set; }

        [JsonPropertyName("voidFlag")]
        public string VoidFlag { get; set; }

        [JsonPropertyName("userReservedDate")]
        public string UserReservedDate { get; set; }

        [JsonPropertyName("userReservedReference")]
        public string UserReservedReference { get; set; }

        [JsonPropertyName("statementDate")]
        public string StatementDate { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("currencyCodeFrom")]
        public string CurrencyCodeFrom { get; set; }

        [JsonPropertyName("unitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [JsonPropertyName("units")]
        public string Units { get; set; }

        [JsonPropertyName("grossAmount")]
        public string GrossAmount { get; set; }

        [JsonPropertyName("nonTaxableAmount")]
        public string NonTaxableAmount { get; set; }

        [JsonPropertyName("foreignNonTaxableAmount")]
        public string ForeignNonTaxableAmount { get; set; }

        [JsonPropertyName("amountTaxable")]
        public string AmountTaxable { get; set; }

        [JsonPropertyName("foreignTaxableAmount")]
        public string ForeignTaxableAmount { get; set; }

        [JsonPropertyName("taxArea")]
        public string TaxArea { get; set; }

        [JsonPropertyName("taxAmount")]
        public string TaxAmount { get; set; }

        [JsonPropertyName("foreignTaxAmount")]
        public string ForeignTaxAmount { get; set; }

        [JsonPropertyName("currencyAmount")]
        public string CurrencyAmount { get; set; }

        [JsonPropertyName("glDate")]
        public string GlDate { get; set; }

        [JsonPropertyName("toCurrency")]
        public string ToCurrency { get; set; }

        [JsonPropertyName("exchangeRateEffectiveDate")]
        public string ExchangeRateEffectiveDate { get; set; }

        [JsonPropertyName("currencyConversionRate")]
        public string CurrencyConversionRate { get; set; }
    }

}
