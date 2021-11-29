using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
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

namespace TCO.SNT.UseCases.Balances.Commands.ImportBalancesInitial
{
    internal class ImportBalancesInitialCommandHandler : IRequestHandler<ImportBalancesInitialCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly IVstoreBalanceService _vstoreBalanceService;
        private readonly CompanyOptions _companyOptions;
        private readonly ISharedModuleContract _sharedModuleContract;

        public ImportBalancesInitialCommandHandler(IDbContext context,
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

        public async Task<int> Handle(ImportBalancesInitialCommand request, CancellationToken cancellationToken)
        {
            var esfBalancesDict = await LoadEsfBalancesAsync(cancellationToken);

            var balances = await MapBalancesAsync(esfBalancesDict, cancellationToken);

            await _context.BulkInsertBalancesAsync(balances, cancellationToken);

            return esfBalancesDict.Count;
        }

        private async Task<IReadOnlyDictionary<BalanceGroupingKey, BalanceGroupingTotal>> LoadEsfBalancesAsync(CancellationToken cancellationToken)
        {
            IReadOnlyList<Balance> esfBalances;
            await using (var session = await _vstoreSessionFactory.CreateUserSessionAsync(null, cancellationToken))
            {
                esfBalances = await _vstoreBalanceService.GetCurrentStatusAsync(session.SessionId);
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

        private async Task<IList<Entities.Balance>> MapBalancesAsync(IReadOnlyDictionary<BalanceGroupingKey, BalanceGroupingTotal> esfBalancesDict, CancellationToken cancellationToken)
        {
            var storesByExternalId = await _context.GetTaxpayerStoresDictByExternalIdAsync(cancellationToken);
            var measureUnitsByCode = await _sharedModuleContract.GetMeasureUnitsDictionaryByCodeAsync(cancellationToken);

            var balances = new List<Entities.Balance>(esfBalancesDict.Count);
            foreach (var esfBalancePair in esfBalancesDict)
            {
                var balance = Entities.Balance.CreateActive();
                _mapper.Map(esfBalancePair.Key, balance);

                balance.SetTaxpayerStore(storesByExternalId[esfBalancePair.Key.TaxpayerStoreId]);
                balance.SetMeasureUnitLink(measureUnitsByCode[esfBalancePair.Key.MeasureUnitCode]);

                // Update Quantity &ReserveQuantity
                balance.UpdateQuantities(esfBalancePair.Value.Quantity, esfBalancePair.Value.ReserveQuantity);

                //Manually update properties not from the key
                balance.UpdatePropertiesNotFromTheKey(esfBalancePair.Value.ProjectCode, esfBalancePair.Value.CanExport);

                balances.Add(balance);
            }

            return balances;
        }
    }
}
