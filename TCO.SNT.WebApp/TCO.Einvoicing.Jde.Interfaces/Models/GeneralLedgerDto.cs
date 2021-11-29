using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class GeneralLedgerDto
    {
        [JsonPropertyName("batchNumber")]
        public string BatchNumber { get; set; }

        [JsonPropertyName("batchDate")]
        public string BatchDate { get; set; }

        [JsonPropertyName("batchType")]
        public string BatchType { get; set; }

        [JsonPropertyName("invoiceDate")]
        public string InvoiceDate { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("accountNumberInpuyt")]
        public string AccountNumberInpuyt { get; set; }

        [JsonPropertyName("jdeLocalization")]
        public string JdeLocalization { get; set; }

        [JsonPropertyName("accountDescription")]
        public string AccountDescription { get; set; }

        [JsonPropertyName("batchStatus")]
        public string BatchStatus { get; set; }
    }

}
