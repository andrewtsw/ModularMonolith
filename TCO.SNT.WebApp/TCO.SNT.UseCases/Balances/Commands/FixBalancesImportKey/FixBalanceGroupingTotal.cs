using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Balances.Commands.FixBalancesImportKey
{
    /// <summary>
    /// This fix should be removed after single run on production
    /// </summary>
    internal class FixBalanceGroupingTotal
    {
        public decimal Quantity { get; set; }

        public decimal? ReserveQuantity { get; set; }

        public long? ProjectCode { get; set; }

        public bool CanExport { get; set; }

        public string CountryCode { get; set; }

        public BalanceDutyType? DutyType { get; set; }
    }
}
