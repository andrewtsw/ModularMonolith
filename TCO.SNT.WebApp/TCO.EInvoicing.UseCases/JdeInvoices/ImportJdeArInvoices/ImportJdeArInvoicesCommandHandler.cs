using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Einvoicing.Jde.Interfaces;
using TCO.Einvoicing.Jde.Interfaces.Models;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities.Jde;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.ImportJdeArInvoices
{
    internal class ImportJdeArInvoicesCommandHandler : IRequestHandler<ImportJdeArInvoicesCommand, ImportJdeArInvoicesResultDto>
    {
        private readonly IEInvoicingDbContext _context;
        private readonly IJdeApimService _jdeApimService;
        private readonly IMapper _mapper;

        public ImportJdeArInvoicesCommandHandler(
            IEInvoicingDbContext context,
            IJdeApimService jdeApimService,
            IMapper mapper)
        {
            _context = context;
            _jdeApimService = jdeApimService;
            _mapper = mapper;
        }

        public async Task<ImportJdeArInvoicesResultDto> Handle(ImportJdeArInvoicesCommand command, CancellationToken cancellationToken)
        {
            var arInvoicesCount = 0;

            var settings = await _context.LoadSettingsAsync(cancellationToken); ;

            do
            {
                var arResponse = await _jdeApimService.GetJdeArInvoicesAsync(settings.JdeArUpdatesLastDateUtc, settings.JdeArNextPageToken, cancellationToken);

                //only posted records
                var filteredArInvoices = arResponse.GetPostedAccountReceivables();
                arInvoicesCount += filteredArInvoices.Count;

                await MergeAsync(filteredArInvoices, cancellationToken);

                settings.JdeArNextPageToken = arResponse.NextPageToken;

                //if NextPageToken is empty, we got all updates until DateTimeOffset.Now
                if (string.IsNullOrWhiteSpace(arResponse.NextPageToken))
                {
                    settings.JdeArUpdatesLastDateUtc = DateTimeOffset.UtcNow;
                }

                await _context.SaveChangesAsync(cancellationToken);
            } while (settings.HasJdeArNextPageToken());

            var result = new ImportJdeArInvoicesResultDto
            {
                Count = arInvoicesCount
            };

            return result;
        }

        private async Task MergeAsync(List<AccountReceivableInvoiceDto> apiInvoices, CancellationToken cancellationToken)
        {
            foreach (var apiInvoice in apiInvoices)
            {
                var dbArInvoice = await _context.JdeArInvoices
                    .SingleOrDefaultAsync(x =>
                    x.JdeArF03B11DocumentNumber == apiInvoice.GetDocumentNumber() &&
                    x.JdeArF03B11DocumentType == apiInvoice.GetDocumentType() &&
                    x.JdeArF03B11DocumentPayItem == apiInvoice.GetDocumentPayItem()
                    , cancellationToken);

                if (dbArInvoice == null)
                {
                    dbArInvoice = JdeArInvoice.CreateNew();

                    _context.JdeArInvoices.Add(dbArInvoice);
                }

                _mapper.Map(apiInvoice, dbArInvoice);
            }
        }
    }
}
