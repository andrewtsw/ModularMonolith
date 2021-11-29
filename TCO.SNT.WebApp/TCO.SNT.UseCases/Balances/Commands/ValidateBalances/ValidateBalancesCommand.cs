using MediatR;

namespace TCO.SNT.UseCases.Balances.Commands.ValidateBalances
{
    public class ValidateBalancesCommand : IRequest<string>
    {
        public long? StoreId { get; }

        public ValidateBalanceDto Dto { get; }

        public ValidateBalancesCommand(long? storeId, ValidateBalanceDto dto)
        {
            StoreId = storeId;
            Dto = dto;
        }
    }
}
