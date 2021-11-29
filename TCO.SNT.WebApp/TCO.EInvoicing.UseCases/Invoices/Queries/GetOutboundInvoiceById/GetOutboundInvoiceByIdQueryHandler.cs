using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.UseCases.Extensions;
using TCO.EInvoicing.UseCases.Invoices.Dto;
using TCO.Finportal.Framework.Domain.Exceptions;

namespace TCO.EInvoicing.UseCases.Invoices.Queries.GetOutboundInvoiceById
{
    internal class GetOutboundInvoiceByIdQueryHandler : IRequestHandler<GetOutboundInvoiceByIdQuery, InvoiceFullDto>
    {
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;

        public GetOutboundInvoiceByIdQueryHandler(
            IEInvoicingDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceFullDto> Handle(GetOutboundInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _context.LoadInvoiceByIdAsync(request.Id, cancellationToken);

            if (!invoice.IsOutbound())
                 throw new EntityNotFoundException(typeof(Invoice).Name);

            var dto = _mapper.Map<InvoiceFullDto>(invoice);
            
            // TODO: remove
            var invoiceV2 = _mapper.Map<EsfApi.Interfaces.Invoices.Models.InvoiceV2>(invoice);
            var body = SNT.Common.Serialization.SerializationHelper.SerializeToXml(invoiceV2, Entities.Invoice.XmlMetaData);
            dto.Boby = body;

            return dto;
        }

    }
}
