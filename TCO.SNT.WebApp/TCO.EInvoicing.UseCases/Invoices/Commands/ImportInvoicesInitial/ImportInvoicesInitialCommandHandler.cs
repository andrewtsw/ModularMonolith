using AutoMapper;
using EsfApiSdk.Invoices;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.EsfApi.Interfaces.Invoices.Models;
using TCO.SNT.Common.Serialization;
using TCO.SNT.EsfApi.Interfaces.Invoices;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.ImportInvoicesInitial
{
    internal class ImportInvoicesInitialCommandHandler : IRequestHandler<ImportInvoicesInitialCommand, ImportInvoicesInitialResultDto>
    {
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfInvoiceService _esfInvoiceService;
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;

        public ImportInvoicesInitialCommandHandler(IEsfApiSessionFactory esfApiSessionFactory, 
            IEsfInvoiceService esfInvoiceService,
            IEInvoicingDbContext сontext,
            IMapper mapper)
        {
            _esfApiSessionFactory = esfApiSessionFactory;
            _esfInvoiceService = esfInvoiceService;
            _context = сontext;
            _mapper = mapper;
        }

        public async Task<ImportInvoicesInitialResultDto> Handle(ImportInvoicesInitialCommand request, CancellationToken cancellationToken)
        {
            var result = new ImportInvoicesInitialResultDto();

            var settings = await _context.LoadSettingsAsync(cancellationToken);
            await using var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken);

            var hasInboundUpdates = true;
            var hasOutboundUpdates = true;
            while (hasInboundUpdates || hasOutboundUpdates)
            {
                if (hasInboundUpdates)
                {
                    var inboundUpdates = await _esfInvoiceService.GetUpdatesAsync(session.SessionId,
                        settings.InvoicesUpdatesInboundLastEventDateUtc.UtcDateTime,
                        settings.InvoicesUpdatesInboundLastInvoiceId,
                        InvoiceDirection.INBOUND, true);

                    var invoices = MapInvoiceInfoToInvoice(inboundUpdates.Updates, Entities.InvoiceDirection.INBOUND);

                    settings.InvoicesUpdatesInboundLastEventDateUtc = inboundUpdates.LastEventDateUtc;
                    settings.InvoicesUpdatesInboundLastInvoiceId = inboundUpdates.LastInvoiceId;

                    await SaveChangesAsync(invoices, cancellationToken);

                    result.AddedInbound += invoices.Count;
                    hasInboundUpdates = !inboundUpdates.IsLastBlock;
                }

                if (hasOutboundUpdates)
                {
                    var outboundUpdates = await _esfInvoiceService.GetUpdatesAsync(session.SessionId,
                        settings.InvoicesUpdatesOutboundLastEventDateUtc.UtcDateTime,
                        settings.InvoicesUpdatesOutboundLastInvoiceId,
                        InvoiceDirection.OUTBOUND, true);

                    var invoices = MapInvoiceInfoToInvoice(outboundUpdates.Updates, Entities.InvoiceDirection.OUTBOUND);

                    settings.InvoicesUpdatesOutboundLastEventDateUtc = outboundUpdates.LastEventDateUtc;
                    settings.InvoicesUpdatesOutboundLastInvoiceId = outboundUpdates.LastInvoiceId;

                    await SaveChangesAsync(invoices, cancellationToken);

                    result.AddedOutbound += invoices.Count;
                    hasOutboundUpdates = !outboundUpdates.IsLastBlock;
                }
            }

            return result;
        }

        private IList<Entities.Invoice> MapInvoiceInfoToInvoice(IReadOnlyList<InvoiceInfo> updates, Entities.InvoiceDirection direction)
        {
            // Ignore V1 invoces
            updates = updates
                .Where(x => x.version == Entities.Invoice.InvoiceV2)
                .ToList();

            if (!updates.Any())
                return new List<Entities.Invoice>(0);

            var result = new List<Entities.Invoice>(updates.Count);

            foreach (var invoiceInfo in updates)
            {
                var invoice = Entities.Invoice.CreateNew(invoiceInfo.invoiceId, direction);
                _mapper.Map(invoiceInfo, invoice.InvoiceInfo);

                var deserialized = SerializationHelper.DeserializeFromXml<InvoiceV2>(invoiceInfo.invoiceBody);

                _mapper.Map(deserialized, invoice);

                result.Add(invoice);
            }
            return result;
        }

        private async Task SaveChangesAsync(IList<Entities.Invoice> invoices, CancellationToken cancellationToken)
        {
            if (invoices.Any())
            {
                using var transaction = await _context.BeginTransactionAsync(cancellationToken);
                await _context.BulkInsertInvoicesAsync(invoices, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            else
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
