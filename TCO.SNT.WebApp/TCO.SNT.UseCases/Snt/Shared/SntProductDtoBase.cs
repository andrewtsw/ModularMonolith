using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.UseCases.Snt.Shared
{
    public abstract class SntProductDtoBase
    {
        /// <summary>
        /// Признак происхождения товара (G1 2, G2 2, G3 2, G4 2, G5 2, G6 2, G7 2, G8 2, G9 2, G10 2)
        /// </summary>
        public int TruOriginCode { get; set; }

        /// <summary>
        /// Наименование товара (G1 3)
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Id остатка на складе
        /// </summary>
        public int? BalanceId { get; set; }

        /// <summary>
        /// Id товара в справочнике ГСВС
        /// </summary>
        public int? GsvsId { get; set; }

        /// <summary>
        /// Id единицы измерения
        /// </summary>
        public int? MeasureUnitId { get; set; }

        /// <summary>
        /// Количество (объем) (G1 6)
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Цена за единицу товара (G1 7)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ставка акциза (G1 9/1, G2 9/2, G3 9/1, G4 13/1, G5 12/2, G6 10/1, G7 9/1, G8 12/1, G9 9/1, G10 12/1)
        /// </summary>
        public decimal? ExciseRate { get; set; }

        /// <summary>
        /// Ставка НДС (G1 10, G2 10, G3 10, G4 14, G5 13, G6 11, G7 10, G8 13, G9 10, G10 13)
        /// </summary>
        public int? NdsRate { get; set; }

        /// <summary>
        /// Дополнительная информация (G1 17, G2 17, G3 17, G4 21, G5 19, G6 17, G7 16, G8 20, G9 16, G10 19)
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
