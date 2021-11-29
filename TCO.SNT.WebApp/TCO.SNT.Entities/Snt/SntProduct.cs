using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Данные по товарам (G1)
    /// </summary>
    public class SntProduct : SntProductBase
    {
        /// <summary>
        /// Наименование товара (G1 3)
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Единица измерения (G1 5)
        /// </summary>
        [Required]
        public string ExternalMeasureUnitCode { get; set; }

        /// <summary>
        /// Количество (объем) (G1 6)
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Цена за единицу товара (G1 7)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Код товара (GTIN) (G1 16)
        /// </summary>
        public string GtinCode { get; set; }


        protected override decimal GetPrice => Price;

        protected override decimal GetQuantity => Quantity;

        protected override void UpdateExternalMeasureUnitCode(string code)
        {
            ExternalMeasureUnitCode = code;
        }
    }
}
