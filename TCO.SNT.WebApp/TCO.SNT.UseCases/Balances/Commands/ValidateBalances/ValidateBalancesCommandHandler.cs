using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Balances.Commands.Shared;

namespace TCO.SNT.UseCases.Balances.Commands.ValidateBalances
{
    internal class ValidateBalancesCommandHandler : IRequestHandler<ValidateBalancesCommand, string>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public ValidateBalancesCommandHandler(IDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(ValidateBalancesCommand request, CancellationToken cancellationToken)
        {
            var balancesDict = await LoadActiveBalancesAsync(request.StoreId, cancellationToken);

            var esfBalancesDict = request.Dto.Rows
                .ToDictionary(x => _mapper.Map<BalanceGroupingKey>(x));

            var sb = new StringBuilder();
            foreach (var balancePair in balancesDict)
            {
                if (esfBalancesDict.TryGetValue(balancePair.Key, out var balanceDto))
                {
                    CompareQuantities(balanceDto, balancePair.Value, balancePair.Key, sb);
                }
                else
                {
                    sb.AppendLine($"Key was not found in ESF data {balancePair.Key}");
                }
            }

            foreach (var esfBalancePair in esfBalancesDict)
            {
                if (balancesDict.TryGetValue(esfBalancePair.Key, out var balance))
                {
                    CompareQuantities(esfBalancePair.Value, balance, esfBalancePair.Key, sb);
                }
                else
                {
                    sb.AppendLine($"Key was not found in INTERNAL data {esfBalancePair.Key}");
                }
            }

            return sb.ToString();
        }

        private void CompareQuantities(BalanceDto value, Entities.Balance balance, BalanceGroupingKey key, StringBuilder sb)
        {
            if (value.Quantity != balance.Quantity)
                sb.AppendLine($"ESF Quantity = {value.Quantity} does not Quantity to internal quantity = {balance.Quantity} for key {key}");

            if (value.ReserveQuantity != balance.ReserveQuantity)
                sb.AppendLine($"ESF ReserveQuantity = {value.ReserveQuantity} does not equals to internal ReserveQuantity = {balance.ReserveQuantity} for key {key}");
        }

        private async Task<IReadOnlyDictionary<BalanceGroupingKey, Entities.Balance>> LoadActiveBalancesAsync(long? storeId, CancellationToken cancellationToken)
        {
            IQueryable<Entities.Balance> query = _context.Balances;

            if (storeId.HasValue)
            {
                var store = await _context.TaxpayerStores.SingleAsync(x => x.ExternalId == storeId.Value, cancellationToken);
                query = query.Where(x => x.TaxpayerStoreId == store.Id);
            }

            var balances = await query
                .Where(x => x.IsActive)
                .ToListAsync(cancellationToken);

            return balances
                .ToDictionary(x => _mapper.Map<BalanceGroupingKey>(x));
        }
    }
}
