using EsfApiSdk.Invoices;
using System;
using System.Collections.Generic;

namespace TCO.SNT.EsfApi.Interfaces.Invoices
{
    public class InvoiceUpdatesDto
    {
        public IReadOnlyList<InvoiceInfo> Updates { get; set; }

        public long LastInvoiceId { get; set; }

        public DateTime LastEventDateUtc { get; set; }

        public bool IsLastBlock { get; set; }
    }
}
