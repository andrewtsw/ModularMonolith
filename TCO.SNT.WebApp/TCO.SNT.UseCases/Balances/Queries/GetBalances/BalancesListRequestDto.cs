using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.UseCases.Balances.Shared;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalances
{
    public class BalancesListRequestDto
    {
        public BalanceFilter Filter { get; set; }

        public SortingModel Sorting { get; set; }

        [Required]
        public RequestPagingModel Paging { get; set; }
    }
}
