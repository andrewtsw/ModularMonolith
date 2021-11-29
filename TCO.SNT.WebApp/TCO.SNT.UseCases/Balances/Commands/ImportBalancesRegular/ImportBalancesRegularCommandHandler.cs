using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Balances.Commands.Shared;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.VStore.Interfaces;
using VsSdk.VstoreBalance;

namespace TCO.SNT.UseCases.Balances.Commands.ImportBalancesRegular
{
    internal class ImportBalancesRegularCommandHandler : IRequestHandler<ImportBalancesRegularCommand, ImportBalancesRegularResultDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly IVstoreBalanceService _vstoreBalanceService;
        private readonly CompanyOptions _companyOptions;
        private readonly ISharedModuleContract _sharedModuleContract;

        public ImportBalancesRegularCommandHandler(IDbContext context,
            IMapper mapper,
            IVstoreSessionFactory vstoreSessionFactory,
            IVstoreBalanceService vstoreBalanceService,
            IOptions<CompanyOptions> companyOptions,
            ISharedModuleContract sharedModuleContract)
        {
            _context = context;
            _mapper = mapper;
            _vstoreSessionFactory = vstoreSessionFactory;
            _vstoreBalanceService = vstoreBalanceService;
            _companyOptions = companyOptions.Value;
            _sharedModuleContract = sharedModuleContract;
        }

        public async Task<ImportBalancesRegularResultDto> Handle(ImportBalancesRegularCommand request, CancellationToken cancellationToken)
        {
            if (!await _context.Balances.AnyAsync(cancellationToken))
            {
                throw new InvalidOperationException("Can not run ImportBalancesRegularCommand because there are no Balances in the DB ");
            }

            var settings = await _context.LoadSettingsAsync(cancellationToken);
            if (!settings.BalancesFixApplied)
            {
                throw new InvalidOperationException("Can not run ImportBalancesRegularCommand because BalancesImportKey fix was not applied");
            }

            var esfBalancesDict = await LoadEsfBalancesAsync(request, cancellationToken);
            var balancesDict = await LoadAciveBalancesAsync(request, cancellationToken);

            var added = await MergeBalancesAsync(esfBalancesDict, balancesDict, cancellationToken);
            var saved = await _context.SaveChangesAsync(cancellationToken);

            var result = new ImportBalancesRegularResultDto
            {
                Added = added
            };
            // Saved should be equals to (result.Added + result.UpdatedAndDeactivated)
            result.UpdatedAndDeactivated = saved - added;
            result.NotChanged = balancesDict.Count - result.UpdatedAndDeactivated;

            return result;
        }

        private async Task<IReadOnlyDictionary<BalanceGroupingKey, Entities.Balance>> LoadAciveBalancesAsync(
            ImportBalancesRegularCommand request, CancellationToken cancellationToken)
        {
            List<Entities.Balance> balances;
            if (request.ProcessUndistributedStore)
            {
                balances = await _context.Balances.ToListAsync(cancellationToken);
            }
            else
            {
                var store = await _context.TaxpayerStores.SingleAsync(x => x.ExternalId == _companyOptions.IgnoredBalancesStoreExternalId, cancellationToken);

                balances = await _context.Balances
                    .Where(x => x.TaxpayerStoreId != store.Id && x.IsActive)
                    .ToListAsync(cancellationToken);
            }

            return balances
                .ToDictionary(x => _mapper.Map<BalanceGroupingKey>(x));
        }

        private async Task<IReadOnlyDictionary<BalanceGroupingKey, BalanceGroupingTotal>> 
            LoadEsfBalancesAsync(ImportBalancesRegularCommand request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Balance> esfBalances;
            await using (var session = await _vstoreSessionFactory.CreateUserSessionAsync(request.UserId, cancellationToken))
            {
                esfBalances = await _vstoreBalanceService.GetCurrentStatusAsync(session.SessionId);
            }

            if (!request.ProcessUndistributedStore)
            {
                esfBalances = esfBalances
                    .Where(x => x.taxpayerStoreId != _companyOptions.IgnoredBalancesStoreExternalId)
                    .ToList();
            }

            // Validate all balances
            esfBalances.ValidateAll(new BalanceValidator(_companyOptions));

            var balancesByKey = new Dictionary<BalanceGroupingKey, BalanceGroupingTotal>(esfBalances.Count);
            foreach (var balance in esfBalances)
            {
                var key = _mapper.Map<BalanceGroupingKey>(balance);
                if (balancesByKey.TryGetValue(key, out var total))
                {
                    total.Quantity += balance.quantity;
                    if (balance.reserveQuantitySpecified)
                        total.ReserveQuantity += balance.reserveQuantity;
                }
                else
                {
                    total = new BalanceGroupingTotal
                    {
                        Quantity = balance.quantity,
                        ReserveQuantity = balance.reserveQuantitySpecified ? balance.reserveQuantity : (decimal?)null,
                        CanExport = balance.canExport,
                        ProjectCode = balance.projectCodeSpecified ? balance.projectCode : (long?)null
                    };
                    balancesByKey.Add(key, total);
                }
            }
            return balancesByKey;
        }

        private async Task<int> MergeBalancesAsync(IReadOnlyDictionary<BalanceGroupingKey, BalanceGroupingTotal> esfBalancesDict,
            IReadOnlyDictionary<BalanceGroupingKey, Entities.Balance> balancesDict,
            CancellationToken cancellationToken)
        {
            var storesByExternalId = await _context.GetTaxpayerStoresDictByExternalIdAsync(cancellationToken);
            var measureUnitsByCode = await _sharedModuleContract.GetMeasureUnitsDictionaryByCodeAsync(cancellationToken);

            // Deactivate all balances
            foreach (var balancePair in balancesDict)
            {
                balancePair.Value.Deactivate();
            }

            var added = 0;
            foreach (var esfBalancePair in esfBalancesDict)
            {
                if (balancesDict.TryGetValue(esfBalancePair.Key, out var balance))
                {
                    balance.Activate();
                }
                else
                {
                    balance = Entities.Balance.CreateActive();
                    _context.Balances.Add(balance);
                    _mapper.Map(esfBalancePair.Key, balance);

                    balance.SetTaxpayerStore(storesByExternalId[esfBalancePair.Key.TaxpayerStoreId]);
                    balance.SetMeasureUnitLink(measureUnitsByCode[esfBalancePair.Key.MeasureUnitCode]);

                    added++;
                }

                // Update Quantity & ReserveQuantity
                balance.UpdateQuantities(esfBalancePair.Value.Quantity, esfBalancePair.Value.ReserveQuantity);

                // Manually update properties not from the key
                balance.UpdatePropertiesNotFromTheKey(esfBalancePair.Value.ProjectCode, esfBalancePair.Value.CanExport);
            }

            return added;
        }
    }
}
