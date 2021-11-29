using System.Text;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Balances.Commands.Shared
{
    internal class BalanceGroupingKey
    {
        public string Tin { get; set; }

        public long TaxpayerStoreId { get; set; }

        // projectCode is ignored

        public string Name { get; set; }

        public string KpvedCode { get; set; }

        public string TnvedCode { get; set; }

        public string GtinCode { get; set; }

        private long productId = 0L;
        public long ProductId
        {
            get => productId;
            set
            {
                productId = value;
                productIdHash = value.GetHashCode();
            }
        }

        private int productIdHash = 0;

        // TODO: add originType property

        public string CountryCode { get; set; }

        public string ProductNameInImportDoc { get; set; }

        public string ManufactureOrImportDocNumber { get; set; }

        public string ProductNumberInImportDoc { get; set; }

        // TODO: add receiptDocNumber, productNumberInReceiptDoc properties

        public BalanceDutyType? DutyType { get; set; }

        public string MeasureUnitCode { get; set; }

        public decimal UnitPrice { get; set; }

        public string PhysicalLabel { get; set; }

        // TODO: add confiscated property
        // TODO: add markingCode property

        public string PinCode { get; set; }

        public decimal? SpiritPercent { get; set; }

        // canExport is ignored

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is BalanceGroupingKey key)
            {
                return
                    key.ProductId == ProductId &&
                    key.GtinCode == GtinCode &&
                    key.KpvedCode == KpvedCode &&
                    key.ManufactureOrImportDocNumber == ManufactureOrImportDocNumber &&
                    key.MeasureUnitCode == MeasureUnitCode &&
                    key.Name == Name &&
                    key.PhysicalLabel == PhysicalLabel &&
                    key.PinCode == PinCode &&
                    key.ProductNameInImportDoc == ProductNameInImportDoc &&
                    key.ProductNumberInImportDoc == ProductNumberInImportDoc &&
                    key.SpiritPercent == SpiritPercent &&
                    key.TaxpayerStoreId == TaxpayerStoreId &&
                    key.Tin == Tin &&
                    key.TnvedCode == TnvedCode &&
                    key.UnitPrice == UnitPrice &&
                    key.CountryCode == CountryCode &&
                    key.DutyType == DutyType;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return productIdHash;
        }

        public override string ToString()
        {
            var sb = new StringBuilder("{");
            sb.Append($"Tin: {Tin}");
            sb.Append($",TaxpayerStoreId: {TaxpayerStoreId}");
            sb.Append($",Name: {Name}");
            sb.Append($",KpvedCode: {KpvedCode}");
            sb.Append($",TnvedCode: {TnvedCode}");
            sb.Append($",GtinCode: {GtinCode}");
            sb.Append($",ProductId: {ProductId}");
            sb.Append($",ManufactureOrImportDocNumber: {ManufactureOrImportDocNumber}");
            sb.Append($",ProductNumberInImportDoc: {ProductNumberInImportDoc}");
            sb.Append($",ProductNameInImportDoc: {ProductNameInImportDoc}");
            sb.Append($",MeasureUnitCode: {MeasureUnitCode}");
            sb.Append($",UnitPrice: {UnitPrice}");
            sb.Append($",PhysicalLabel: {PhysicalLabel}");
            sb.Append($",PinCode: {PinCode}");
            sb.Append($",SpiritPercent: {SpiritPercent}");
            sb.Append($",DutyType: {DutyType}");
            sb.Append($",CountryCode: {CountryCode}");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
