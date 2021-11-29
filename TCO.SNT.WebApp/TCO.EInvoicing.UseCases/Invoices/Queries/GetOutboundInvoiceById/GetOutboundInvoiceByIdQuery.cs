using MediatR;
using TCO.EInvoicing.UseCases.Invoices.Dto;

namespace TCO.EInvoicing.UseCases.Invoices.Queries.GetOutboundInvoiceById
{
    public class GetOutboundInvoiceByIdQuery : IRequest<InvoiceFullDto>
    {
        public int Id { get; }

        public GetOutboundInvoiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
