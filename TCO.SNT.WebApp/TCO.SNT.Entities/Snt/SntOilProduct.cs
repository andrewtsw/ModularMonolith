using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Данные по нефтепродуктам (G6)
    /// </summary>
    public class SntOilProduct : SntProductBase
    {
        /// <summary>
        /// ПИН-код (G6 3)
        /// </summary>
        [Required]
        public string PinCode { get; set; }

        /// <summary>
        /// Вид, марка нефтепродукта (G6 4)
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Цена товара за тонну (G6 8)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Единица измерения товара (Тонна, Литр) (G6 6)
        /// </summary>
        [Required]
        public string ExternalMeasureUnitCode { get; set; }

        /// <summary>
        /// Количество товара в  тоннах, (в литрах для розницы) (G6 7)
        /// </summary>
        public decimal Quantity { get; set; }


        protected override decimal GetPrice => Price;

        protected override decimal GetQuantity => Quantity;

        protected override void UpdateExternalMeasureUnitCode(string code)
        {
            ExternalMeasureUnitCode = code;
        }

        public override void SetBalance(Balance balance)
        {
            base.SetBalance(balance);

            PinCode = balance.PinCode;
            ProductName = balance.Name;
        }
    }
}
