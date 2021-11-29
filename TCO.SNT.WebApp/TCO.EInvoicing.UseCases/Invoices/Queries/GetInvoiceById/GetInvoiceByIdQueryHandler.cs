using AutoMapper;
using EsfApiSdk.Invoices;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.UseCases.Extensions;
using TCO.EInvoicing.UseCases.Invoices.Dto;
using TCO.SNT.Common.Options;
using TCO.SNT.EsfApi.Interfaces.Invoices;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.EInvoicing.UseCases.Invoices.Queries.GetInvoiceById
{
    //internal class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceFullDto>
    //{
    //    private readonly IEInvoicingDbContext _context;
    //    private readonly IMapper _mapper;
    //    private readonly IEsfApiSessionFactory _esfApiSessionFactory;
    //    private readonly IEsfInvoiceService _esfInvoiceService;
    //    private readonly CompanyOptions _companyOptions;

    //    public GetInvoiceByIdQueryHandler(
    //        IEInvoicingDbContext context,
    //        IMapper mapper,
    //        IEsfApiSessionFactory esfApiSessionFactory,
    //        IEsfInvoiceService esfInvoiceService,
    //        IOptions<CompanyOptions> companyOptions
    //        )
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //        _esfApiSessionFactory = esfApiSessionFactory;
    //        _esfInvoiceService = esfInvoiceService;
    //        _companyOptions = companyOptions.Value;
    //    }

    //    public async Task<InvoiceFullDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        var invoice = await _context.LoadInvoiceByIdAsync(request.Id, cancellationToken);

    //        await MarkInvoiceAsDeliveredIfNotViewed(invoice, cancellationToken);

    //        var dto = _mapper.Map<InvoiceFullDto>(invoice);

    //        return dto;
    //    }

    //    private async Task MarkInvoiceAsDeliveredIfNotViewed(Invoice invoice, CancellationToken cancellationToken)
    //    {
    //        if (!invoice.NeedToDeliver())
    //            return;

    //        InvoiceSummary invoiceSummary;
    //        await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
    //        {
    //            invoiceSummary = await _esfInvoiceService.SetDeliveredStatusAsync(session.SessionId, invoice.ExternalId.Value);
    //        }

    //        _mapper.Map(invoiceSummary, invoice.InvoiceInfo);

    //        await _context.SaveChangesAsync(CancellationToken.None);
    //    }
    //}
}
