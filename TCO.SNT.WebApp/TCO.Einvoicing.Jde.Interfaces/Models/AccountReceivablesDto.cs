using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class AccountReceivablesDto
    {
        public const string PostedBatchStatus = "D";


        [JsonPropertyName("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonPropertyName("accountReceivables")]
        public List<AccountReceivableInvoiceDto> AccountReceivables { get; set; }

        public List<AccountReceivableInvoiceDto> GetPostedAccountReceivables()
        {
            return AccountReceivables?.FindAll(x => x.GeneralLedger?.BatchStatus == PostedBatchStatus) ?? new List<AccountReceivableInvoiceDto>();
        }
    }
}
