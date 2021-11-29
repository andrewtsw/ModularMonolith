using System.Collections.Generic;
using TCO.Finportal.Framework.UseCases;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalances
{
    public class BalancesListResponseDto
    {
        public PagingModel Paging { get; set; }

        public IReadOnlyList<BalanceSimpleDto> Balances { get; set; }
    }
}