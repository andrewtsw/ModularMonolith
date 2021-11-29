using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SendInvoice
{
    public class SendInvoiceDto
    {
        /// <summary>
        /// Invoice.Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Timezone offset from the client in minutes
        /// </summary>
        [Range(-14 * 60, 14 * 60)]
        public int LocalTimezoneOffsetMinutes { get; set; }
    }
}
