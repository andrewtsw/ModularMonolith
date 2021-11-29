using AutoMapper;
using EsfApiSdk.UploadInvoice;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.EsfApi.Interfaces.Invoices.Models;
using TCO.EInvoicing.UseCases.Extensions;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Extensions;
using TCO.SNT.EsfApi.Interfaces.Invoices;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.UploadInvoice;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SendInvoice
{
    internal class SendInvoiceCommandHandler : AsyncRequestHandler<SendInvoiceCommand>
    {
        private readonly IEsfUploadInvoiceService _esfUploadInvoiceService;
        private readonly ISharedModuleContract _sharedModuleContract;
        private readonly IMapper _mapper;
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEInvoicingDbContext _context;
        private readonly IEsfInvoiceService _esfInvoiceService;
        private readonly ICurrentUserNameableService _currentUserService;
        private readonly IDateTime _dateTime;

        public SendInvoiceCommandHandler(IEsfUploadInvoiceService esfUploadInvoiceService, ISharedModuleContract sharedModuleContract, IMapper mapper, IEsfApiSessionFactory esfApiSessionFactory, IEInvoicingDbContext context, IEsfInvoiceService esfInvoiceService, ICurrentUserNameableService currentUserService, IDateTime dateTime)
        {
            _esfUploadInvoiceService = esfUploadInvoiceService;
            _sharedModuleContract = sharedModuleContract;
            _mapper = mapper;
            _esfApiSessionFactory = esfApiSessionFactory;
            _context = context;
            _esfInvoiceService = esfInvoiceService;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        protected override async Task Handle(SendInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _context.LoadInvoiceByIdAsync(request.Dto.Id, cancellationToken);

            invoice.ValidateInvoiceStatus();

            await UpdateInvoiceDatesAsync(invoice, request.Dto.LocalTimezoneOffsetMinutes, cancellationToken);

            await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
            {
                await UploadInvoiceAsync(invoice, session, cancellationToken);
                await UpdateInvoiceInfoAsync(invoice, session);
            }
        }

        private async Task UpdateInvoiceDatesAsync(Invoice invoice, int offsetMinutes, CancellationToken cancellationToken)
        {
            invoice.UpdateUtcDates(_dateTime.UtcNow);
            invoice.Date = _dateTime.UtcNow.SetDateWithOffset(offsetMinutes);

            invoice.OperatorFullname = _currentUserService.Name;

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task UploadInvoiceAsync(Invoice invoice, IEsfApiSession session, CancellationToken cancellationToken)
        {
            var invoiceV2 = _mapper.Map<InvoiceV2>(invoice);

            var signatureInfo = await _sharedModuleContract.CreateSignatureAsync(invoiceV2, Invoice.XmlMetaData, cancellationToken);

            var upload = await _esfUploadInvoiceService.SyncInvoiceAsync(session.SessionId, signatureInfo);

            var externalId = GetExternalIdFromValidatedResponse(upload);
            invoice.SetExternalId(externalId);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateInvoiceInfoAsync(Invoice invoice, IEsfApiSession session)
        {
            var invoiceInfo = await _esfInvoiceService.GetInvoiceByIdAsync(session.SessionId, invoice.ExternalId.Value);
            _mapper.Map(invoiceInfo, invoice.InvoiceInfo);

            await _context.SaveChangesAsync(CancellationToken.None);
        }


        private long GetExternalIdFromValidatedResponse(SyncInvoiceResponse response)
        {
            if (response.declinedSet.Any())
            {
                var errors = _mapper.Map<Finportal.Framework.Domain.Entities.Error[]>(response.declinedSet.Single().errors);
                throw new EsfOperationFailedException("Invoice upload error: Invoice was declined", errors);
            }

            var result = response.acceptedSet.Single();
            if (!result.idSpecified || result.id <= 0)
            {
                throw new EsfOperationFailedException("Invoice upload error: id must be positive");
            }

            return result.id;
        }

    }
}
