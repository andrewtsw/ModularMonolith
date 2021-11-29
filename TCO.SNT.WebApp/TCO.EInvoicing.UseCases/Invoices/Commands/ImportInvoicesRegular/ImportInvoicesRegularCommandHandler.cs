using AutoMapper;
using EsfApiSdk.Invoices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.EsfApi.Interfaces.Invoices.Models;
using TCO.SNT.Common.Serialization;
using TCO.SNT.EsfApi.Interfaces.Invoices;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.ImportInvoicesRegular
{
    internal class ImportInvoicesRegularCommandHandler : IRequestHandler<ImportInvoicesRegularCommand, ImportInvoicesRegularResultDto>
    {
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfInvoiceService _esfInvoiceService;
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;

        public ImportInvoicesRegularCommandHandler(IEsfApiSessionFactory esfApiSessionFactory,
            IEsfInvoiceService esfInvoiceService,
            IEInvoicingDbContext сontext,
            IMapper mapper)
        {
            _esfApiSessionFactory = esfApiSessionFactory;
            _esfInvoiceService = esfInvoiceService;
            _context = сontext;
            _mapper = mapper;
        }

        public async Task<ImportInvoicesRegularResultDto> Handle(ImportInvoicesRegularCommand request, CancellationToken cancellationToken)
        {
            if (!await _context.Invoices.AnyAsync(cancellationToken))
            {
                throw new InvalidOperationException("Can not run ImportInvoicesRegularCommand because there are no Invoices in the DB ");
            }

            var settings = await _context.LoadSettingsAsync(cancellationToken);

            InvoiceUpdatesDto inboundUpdates;
            InvoiceUpdatesDto outboundUpdates;
            await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
            {
                inboundUpdates = await _esfInvoiceService.GetAllUpdatesAsync(session.SessionId,
                    settings.InvoicesUpdatesInboundLastEventDateUtc.UtcDateTime,
                    settings.InvoicesUpdatesInboundLastInvoiceId,
                    InvoiceDirection.INBOUND, true);

                outboundUpdates = await _esfInvoiceService.GetAllUpdatesAsync(session.SessionId,
                    settings.InvoicesUpdatesOutboundLastEventDateUtc.UtcDateTime,
                    settings.InvoicesUpdatesOutboundLastInvoiceId,
                    InvoiceDirection.OUTBOUND, true);
            }

            var result = new ImportInvoicesRegularResultDto();

            var inboundStats = await MergeAsync(inboundUpdates.Updates, Entities.InvoiceDirection.INBOUND, cancellationToken);
            result.InboundAdded = inboundStats.Added;
            result.InboundUpdated = inboundStats.Updated;

            settings.InvoicesUpdatesInboundLastEventDateUtc = inboundUpdates.LastEventDateUtc;
            settings.InvoicesUpdatesInboundLastInvoiceId = inboundUpdates.LastInvoiceId;

            await _context.SaveChangesAsync(cancellationToken);

            var outboundStats = await MergeAsync(outboundUpdates.Updates, Entities.InvoiceDirection.OUTBOUND, cancellationToken);
            result.OutboundAdded = outboundStats.Added;
            result.OutboundUpdated = outboundStats.Updated;

            settings.InvoicesUpdatesOutboundLastEventDateUtc = outboundUpdates.LastEventDateUtc;
            settings.InvoicesUpdatesOutboundLastInvoiceId = outboundUpdates.LastInvoiceId;

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        private async Task<(int Added, int Updated)> MergeAsync(IReadOnlyList<InvoiceInfo> updates, Entities.InvoiceDirection direction, CancellationToken cancellationToken)
        {
            int added = 0, updated = 0;

            // Ignore V1 invoces
            updates = updates
                .Where(x => x.version == Entities.Invoice.InvoiceV2)
                .ToList();

            foreach (var update in updates)
            {
                var invoice = await _context.Invoices
                    .Include(x => x.InvoiceInfo)
                    .SingleOrDefaultAsync(x => x.ExternalId == update.invoiceId, cancellationToken);

                if (invoice == null)
                {
                    invoice = Entities.Invoice.CreateNew(update.invoiceId, direction);
                    _context.Invoices.Add(invoice);
                    added++;
                }
                else
                {
                    updated++;
                }

                _mapper.Map(update, invoice.InvoiceInfo);

                if (invoice.IsNew())
                {
                    var deserialized = SerializationHelper.DeserializeFromXml<InvoiceV2>(update.invoiceBody);

                    _mapper.Map(deserialized, invoice);
                }
            }

            return (added, updated);
        }
    }
}
