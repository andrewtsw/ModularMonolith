namespace TCO.SNT.UseCases.Balances.Commands.Shared
{
    internal class BalanceGroupingTotal
    {
        public decimal Quantity { get; set; }

        public decimal? ReserveQuantity { get; set; }

        public long? ProjectCode { get; set; }

        public bool CanExport { get; set; }
    }
}
