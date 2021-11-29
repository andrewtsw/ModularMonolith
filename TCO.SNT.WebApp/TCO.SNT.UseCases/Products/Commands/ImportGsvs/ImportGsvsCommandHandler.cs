using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.VStore.Interfaces;
using VsSdk.Dictionaries;

namespace TCO.SNT.UseCases.Products.Commands.ImportGsvs
{
    internal class ImportGsvsCommandHandler : IRequestHandler<ImportGsvsCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly IVstoreDictionariesService _vstoreDictionariesService;
        private readonly IMapper _mapper;

        public ImportGsvsCommandHandler(IDbContext context,
            IVstoreSessionFactory vstoreSessionFactory,
            IVstoreDictionariesService vstoreDictionariesService,
            IMapper mapper)
        {
            _context = context;
            _vstoreSessionFactory = vstoreSessionFactory;
            _vstoreDictionariesService = vstoreDictionariesService;
            _mapper = mapper;
        }

        public async Task<int> Handle(ImportGsvsCommand request, CancellationToken cancellationToken)
        {
            var settings = await _context.LoadSettingsAsync(cancellationToken);

            GsvsUpdatesDto updates = null;
            await using (var session = await _vstoreSessionFactory.CreateSessionAsync(cancellationToken))
            {
                updates = await _vstoreDictionariesService.GetGsvsUpdates(session.SessionId, settings.GsvsLastChangeId);
            }

            if (updates.Updates.Any())
            {
                updates.Updates.ValidateAll(x => x.gsvs, new GsvsValidator());

                await ProcessGsvsUpdatesAsync(updates.Updates, cancellationToken);
                settings.GsvsLastChangeId = updates.LastChangeId;

                await _context.SaveChangesAsync(cancellationToken);
            }

            return updates.Updates.Count;
        }

        private async Task ProcessGsvsUpdatesAsync(IReadOnlyList<GsvsUpdate> updates, CancellationToken cancellationToken)
        {
            var gsvsByFixedId = new Dictionary<long, Product>();
            foreach (var update in updates)
            {
                switch (update.operation)
                {
                    case eGsvsOperation.ADD:
                        var addedProduct = new Product();
                        _context.Products.Add(addedProduct);
                        _mapper.Map(update.gsvs, addedProduct);
                        gsvsByFixedId.Add(addedProduct.FixedId, addedProduct);
                        break;
                    case eGsvsOperation.UPDATE:
                        if (!gsvsByFixedId.TryGetValue(update.gsvs.fixedId, out var updatedProduct))
                        {
                            updatedProduct = await _context.Products
                                .SingleOrExceptionAsync(x => x.FixedId == update.gsvs.fixedId, cancellationToken);
                            gsvsByFixedId.Add(updatedProduct.FixedId, updatedProduct);
                        }
                        _mapper.Map(update.gsvs, updatedProduct);
                        break;
                    case eGsvsOperation.DELETE:
                        if (!gsvsByFixedId.TryGetValue(update.gsvs.fixedId, out var deletedProduct))
                        {
                            deletedProduct = await _context.Products
                                .SingleOrExceptionAsync(x => x.FixedId == update.gsvs.fixedId, cancellationToken);
                            gsvsByFixedId.Add(deletedProduct.FixedId, deletedProduct);
                        }
                        _mapper.Map(update.gsvs, deletedProduct);
                        deletedProduct.IsDeleted = true;
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown eGsvsOperation = {update.operation}");
                }
            }
        }
    }
}
