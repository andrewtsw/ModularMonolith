using TCO.Finportal.Framework.UseCases;
using TCO.SNT.UseCases.Balances.Shared;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalanceReport
{
    public class BalanceListReportRequestDto
    {
        public BalanceFilter Filter { get; set; }

        public SortingModel Sorting { get; set; }
    }
}
