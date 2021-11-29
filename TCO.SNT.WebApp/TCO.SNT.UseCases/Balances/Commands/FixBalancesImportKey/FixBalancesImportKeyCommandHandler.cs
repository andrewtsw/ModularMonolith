using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Balances.Commands.Shared;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.VStore.Interfaces;
using VsSdk.VstoreBalance;
using DomainEntities = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.Balances.Commands.FixBalancesImportKey
{
    /// <summary>
    /// This fix should be removed after single run on production
    /// </summary>
    internal class FixBalancesImportKeyCommandHandler : IRequestHandler<FixBalancesImportKeyCommand, FixBalancesImportKeyResultDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly IVstoreBalanceService _vstoreBalanceService;
        private readonly CompanyOptions _companyOptions;
        private readonly ISharedModuleContract _sharedModuleContract;

        private IDictionary<long, Entities.TaxpayerStore> StoresByExternalId;
        private IDictionary<string, MeasureUnit> MeasureUnitsByCode;

        public FixBalancesImportKeyCommandHandler(IDbContext context,
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

        public async Task<FixBalancesImportKeyResultDto> Handle(FixBalancesImportKeyCommand request, CancellationToken cancellationToken)
        {
            var settings = await _context.LoadSettingsAsync(cancellationToken);

            if (settings.BalancesFixApplied)
            {
                throw new InvalidOperationException("");
            }

            var esfBalances = await LoadEsfBalances(cancellationToken);

            await LoadDictionariesAsync(cancellationToken);

            var undistributedBalances = ProcessUndistributedBalances(esfBalances);

            await ProcessOtherBalancesAsync(esfBalances, cancellationToken);

            settings.BalancesFixApplied = true;
            var saved = await SaveChangesAsync(undistributedBalances, cancellationToken);

            return new FixBalancesImportKeyResultDto { Saved = saved, Added = undistributedBalances.Count };
        }

        private async Task<int> SaveChangesAsync(IList<Entities.Balance> undistributedBalances, CancellationToken cancellationToken)
        {
            using var transaction = await _context.BeginTransactionAsync(cancellationToken);
            await _context.BulkInsertBalancesAsync(undistributedBalances, cancellationToken);
            var saved = await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return saved;
        }

        private async Task LoadDictionariesAsync(CancellationToken cancellationToken)
        {
            StoresByExternalId = await _context.GetTaxpayerStoresDictByExternalIdAsync(cancellationToken);
            MeasureUnitsByCode = await _sharedModuleContract.GetMeasureUnitsDictionaryByCodeAsync(cancellationToken);
        }


        private IList<Entities.Balance> ProcessUndistributedBalances(IReadOnlyList<Balance> esfBalances)
        {
            var undistributedEsfBalances = esfBalances
                .Where(x => x.taxpayerStoreId == _companyOptions.IgnoredBalancesStoreExternalId)
                .ToList();

            var undistributedEsfBalancesDict = GroupEsfBalancesByKey(undistributedEsfBalances);

            var undistributedBalances = MapBalances(undistributedEsfBalancesDict);

            return undistributedBalances;
        }

        private async Task ProcessOtherBalancesAsync(IReadOnlyList<Balance> esfBalances, CancellationToken cancellationToken)
        {
            var otherEsfBalances = esfBalances
                .Where(x => x.taxpayerStoreId != _companyOptions.IgnoredBalancesStoreExternalId)
                .ToList();

            var otherEsfBalancesDict = GroupEsfBalancesByKey(otherEsfBalances);

            var otherBalancesDict = await LoadBalancesAsync(cancellationToken);

            MergeBalances(otherEsfBalancesDict, otherBalancesDict);
        }

        private IReadOnlyDictionary<FixBalanceGroupingKey, FixBalanceGroupingTotal> GroupEsfBalancesByKey(IReadOnlyList<Balance> esfBalances)
        {
            var balancesByKey = new Dictionary<FixBalanceGroupingKey, FixBalanceGroupingTotal>(esfBalances.Count);
            foreach (var balance in esfBalances)
            {
                var key = _mapper.Map<FixBalanceGroupingKey>(balance);
                if (balancesByKey.TryGetValue(key, out var total))
                {
                    total.Quantity += balance.quantity;
                    if (balance.reserveQuantitySpecified)
                        total.ReserveQuantity += balance.reserveQuantity;
                }
                else
                {
                    total = new FixBalanceGroupingTotal
                    {
                        Quantity = balance.quantity,
                        ReserveQuantity = balance.reserveQuantitySpecified ? balance.reserveQuantity : (decimal?)null,
                        CanExport = balance.canExport,
                        ProjectCode = balance.projectCodeSpecified ? balance.projectCode : (long?)null,
                        CountryCode = balance.countryCode,
                        DutyType = balance.dutyTypeSpecified ? (Entities.BalanceDutyType)balance.dutyType : (Entities.BalanceDutyType?)null
                    };
                    balancesByKey.Add(key, total);
                }
            }
            return balancesByKey;
        }

        private async Task<IReadOnlyList<Balance>> LoadEsfBalances(CancellationToken cancellationToken)
        {
            await using var session = await _vstoreSessionFactory.CreateUserSessionAsync(null, cancellationToken);
            var esfBalances = await _vstoreBalanceService.GetCurrentStatusAsync(session.SessionId);
            esfBalances.ValidateAll(new BalanceValidator(_companyOptions));
            return esfBalances;
        }

        private async Task<IReadOnlyDictionary<FixBalanceGroupingKey, Entities.Balance>> LoadBalancesAsync(CancellationToken cancellationToken)
        {
            var balances = await _context.Balances.ToListAsync(cancellationToken);
            return balances.ToDictionary(x => _mapper.Map<FixBalanceGroupingKey>(x));
        }

        private IList<Entities.Balance> MapBalances(IReadOnlyDictionary<FixBalanceGroupingKey, FixBalanceGroupingTotal> esfBalancesDict)
        {
            var balances = new List<Entities.Balance>(esfBalancesDict.Count);
            foreach (var esfBalancePair in esfBalancesDict)
            {
                var balance = Entities.Balance.CreateActive();
                _mapper.Map(esfBalancePair.Key, balance);

                balance.SetTaxpayerStore(StoresByExternalId[esfBalancePair.Key.TaxpayerStoreId]);
                balance.SetMeasureUnitLink(MeasureUnitsByCode[esfBalancePair.Key.MeasureUnitCode]);

                // Update Quantity &ReserveQuantity
                balance.UpdateQuantities(esfBalancePair.Value.Quantity, esfBalancePair.Value.ReserveQuantity);

                //Manually update properties not from the key
                balance.UpdatePropertiesNotFromTheKey(esfBalancePair.Value.ProjectCode, esfBalancePair.Value.CanExport);

                // Map new 
                balance.CountryCode = esfBalancePair.Value.CountryCode;
                balance.DutyType = esfBalancePair.Value.DutyType;

                balances.Add(balance);
            }

            return balances;
        }

        private void MergeBalances(IReadOnlyDictionary<FixBalanceGroupingKey, FixBalanceGroupingTotal> esfBalancesDict,
            IReadOnlyDictionary<FixBalanceGroupingKey, Entities.Balance> balancesDict)
        {
            // Deactivate all balances
            foreach (var balancePair in balancesDict)
            {
                balancePair.Value.Deactivate();
            }

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

                    balance.SetTaxpayerStore(StoresByExternalId[esfBalancePair.Key.TaxpayerStoreId]);
                    balance.SetMeasureUnitLink(MeasureUnitsByCode[esfBalancePair.Key.MeasureUnitCode]);
                }

                // Update Quantity & ReserveQuantity
                balance.UpdateQuantities(esfBalancePair.Value.Quantity, esfBalancePair.Value.ReserveQuantity);

                // Manually update properties not from the key
                balance.UpdatePropertiesNotFromTheKey(esfBalancePair.Value.ProjectCode, esfBalancePair.Value.CanExport);

                // 
                balance.CountryCode = esfBalancePair.Value.CountryCode;
                balance.DutyType = esfBalancePair.Value.DutyType;
            }
        }
    }
}
