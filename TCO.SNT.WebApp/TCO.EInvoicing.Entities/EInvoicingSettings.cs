using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCO.EInvoicing.Entities
{
    public class EInvoicingSettings
    {
        // Can not use a private setter because public setter used to create a single instance in DbContext.
        public int Id { get; set; }

        public DateTimeOffset InvoicesUpdatesInboundLastEventDateUtc { get; set; }

        public long InvoicesUpdatesInboundLastInvoiceId { get; set; }

        public DateTimeOffset InvoicesUpdatesOutboundLastEventDateUtc { get; set; }

        public long InvoicesUpdatesOutboundLastInvoiceId { get; set; }

        public DateTimeOffset AwpUpdatesLastEventDateUtc { get; set; }

        public long AwpUpdatesLastAwpId { get; set; }

        public DateTimeOffset JdeArUpdatesLastDateUtc { get; set; }

        public string JdeArNextPageToken { get; set; }

        public bool HasJdeArNextPageToken()
        {
            return !string.IsNullOrWhiteSpace(JdeArNextPageToken);
        }
    }
}
