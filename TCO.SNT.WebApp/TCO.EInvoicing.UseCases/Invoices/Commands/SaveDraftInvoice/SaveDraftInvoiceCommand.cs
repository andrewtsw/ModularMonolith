using MediatR;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    public class SaveDraftInvoiceCommand : IRequest<int>
    {
        public InvoiceDto Dto { get; }

        public SaveDraftInvoiceCommand(InvoiceDto dto)
        {
            Dto = dto;
        }
    }
}
