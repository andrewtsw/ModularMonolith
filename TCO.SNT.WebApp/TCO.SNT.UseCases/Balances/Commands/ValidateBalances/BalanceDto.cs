using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Balances.Commands.ValidateBalances
{
    public class BalanceDto
    {
        /// <summary>
        /// Compare
        /// </summary>
        [Required]
        public string Tin { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public long StoreId { get; set; }

        /// <summary>
        /// Ignore, additional UI field
        /// </summary>
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// Ignore, because not the key
        /// </summary>
        public long? ProjectCode { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public string OriginType { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        [Required]
        public string KpvedCode { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        [Required]
        public string TnvedCode { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public string GtinCode { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public string ReceiptDocNumber { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public string ProductNumberInReceiptDoc { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public string DutyTypeCode { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public string ManufactureOrImportCountry { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Ignore, additional UI field
        /// </summary>
        public int MeasureUnitId { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        [Required]
        public string MeasureUnitCode { get; set; }

        /// <summary>
        /// Ignore, additional UI field
        /// </summary>
        [Required]
        public string MeasureUnitName { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public string ManufactureOrImportDocNumber { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public string ProductNumberInImportDoc { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public string ProductNameInImportDoc { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public string PhysicalLabel { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public decimal? SpiritPercent { get; set; }

        /// <summary>
        /// Ignore, because not the key
        /// </summary>
        public bool? CanExport { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Compare
        /// </summary>
        public decimal ReserveQuantity { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public bool Confiscated { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public bool IsEverUsedInVstore { get; set; }

        /// <summary>
        /// Ignore, not exists in internal model
        /// </summary>
        public int OriginTypeCode { get; set; }

        /// <summary>
        /// Ignore, additional UI field
        /// </summary>
        [Required]
        public string GsvsCode { get; set; }

        /// <summary>
        /// Ignore, additional UI field
        /// </summary>
        public decimal AvailableQuantity { get; set; }

        public string CountryCode { get; set; }

        public BalanceDutyType? DutyType { get; set; }
    }
}
