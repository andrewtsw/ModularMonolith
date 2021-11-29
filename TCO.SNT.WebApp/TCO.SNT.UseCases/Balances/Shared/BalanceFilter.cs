namespace TCO.SNT.UseCases.Balances.Shared
{
    public class BalanceFilter
	{
        public string Name { get; set; }

        public string ProductNameInImportDoc { get; set; }

        public string ProductNumberInImportDoc { get; set; }

        public string ManufactureOrImportDocNumber { get; set; }

        public long? ProductId { get; set; }

        public decimal? UnitPrice { get; set; }

        public string KpvedCode { get; set; }

        public string TnvedCode { get; set; }

        public string GtinCode { get; set; }

        public string PhysicalLabel { get; set; }

        public int? TaxpayerStoreId { get; set; }

        public int? MeasureUnitId { get; set; }

    }
}
