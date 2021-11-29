using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.VStore.Interfaces;
using VsSdk.TaxpayerStore;

namespace TCO.SNT.UseCases.TaxpayerStores.Commands.ImportTaxpayerStores
{
    internal class ImportTaxpayerStoresCommandHandler : IRequestHandler<ImportTaxpayerStoresCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly ITaxpayerStoreService _taxpayerStoreService;
        private readonly CompanyOptions _companyOptions;
        private readonly IMapper _mapper;

        public ImportTaxpayerStoresCommandHandler(IDbContext context,
            IVstoreSessionFactory vstoreSessionFactory,
            ITaxpayerStoreService taxpayerStoreService,
            IOptions<CompanyOptions> companyOptions,
            IMapper mapper)
        {
            _context = context;
            _vstoreSessionFactory = vstoreSessionFactory;
            _taxpayerStoreService = taxpayerStoreService;
            _companyOptions = companyOptions.Value;
            _mapper = mapper;
        }

        public async Task<int> Handle(ImportTaxpayerStoresCommand request, CancellationToken cancellationToken)
        {
            IReadOnlyList<TaxpayerStore> externalStores = null;
            await using (var session = await _vstoreSessionFactory.CreateSessionAsync(cancellationToken))
            {
                externalStores = await _taxpayerStoreService.GetAllAsync(session.SessionId);
            }

            ValidateStores(externalStores);

            var internalStores = await _context.TaxpayerStores.ToListAsync(cancellationToken);
            NotifyAboutMissedStores(internalStores, externalStores);

            CreateOrUpdate(externalStores, internalStores);
            await _context.SaveChangesAsync(cancellationToken);

            return externalStores.Count;
        }

        private void ValidateStores(IEnumerable<TaxpayerStore> stores)
        {
            stores.ValidateAll(new TaxpayerStoreValidator(_companyOptions));
           
            var defaultStoresCount = stores.Count(x => x.isDefault);
            if (defaultStoresCount > 1)
            {
                throw new ValidationException("Приоритетный склад должен быть только один");
            }
        }

        private void NotifyAboutMissedStores(IEnumerable<Entities.TaxpayerStore> internalStores, IEnumerable<TaxpayerStore> externalStores)
        {
            var externalStoresById = externalStores.ToDictionary(x => x.id);

            foreach (var internalStore in internalStores)
            {
                if (!externalStoresById.ContainsKey(internalStore.ExternalId))
                {
                    throw new ValidationException($"Склад Id = {internalStore.Id} был удален из ЭСФ портала.");
                }
            }
        }

        private void CreateOrUpdate(IReadOnlyList<TaxpayerStore> externalStores, IReadOnlyList<Entities.TaxpayerStore> internalStores)
        {
            var internalStoresByExternalId = internalStores.ToDictionary(x => x.ExternalId);

            foreach (var externalStore in externalStores)
            {
                if (!internalStoresByExternalId.TryGetValue(externalStore.id, out var internalStore))
                {
                    internalStore = new Entities.TaxpayerStore { ExternalId = externalStore.id };
                    _context.TaxpayerStores.Add(internalStore);
                }

                _mapper.Map(externalStore, internalStore);
            }
        }
    }
}
