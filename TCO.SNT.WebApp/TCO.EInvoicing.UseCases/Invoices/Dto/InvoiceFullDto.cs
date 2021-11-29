using System;

namespace TCO.EInvoicing.UseCases.Invoices.Dto
{
    public class InvoiceFullDto
    {
        public string RegistrationNumber { get; set; }

        public DateTime? Date { get; set; }

        // TODO: remove
        public string Boby { get; set; }
    }
}
