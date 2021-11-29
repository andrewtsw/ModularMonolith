namespace TCO.EInvoicing.UseCases.Invoices.Commands.ImportInvoicesRegular
{
    public class ImportInvoicesRegularResultDto
    {
        public int InboundAdded { get; set; }

        public int InboundUpdated { get; set; }

        public int OutboundAdded { get; set; }

        public int OutboundUpdated { get; set; }
    }
}
