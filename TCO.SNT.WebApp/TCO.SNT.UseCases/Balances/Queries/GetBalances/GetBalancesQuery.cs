using MediatR;
using TCO.SNT.UseCases.Balances.Shared;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalances
{
    public class GetBalancesQuery : IRequest<BalancesListResponseDto>
    {
        public BalancesListRequestDto Dto { get; }

        public GetBalancesQuery(BalancesListRequestDto dto)
        {
            Dto = dto;
        }
    }
}
