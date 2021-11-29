using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalances
{
    public class BalanceSimpleDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя склада
        /// </summary>
        [Required]
        public string TaxpayerStoreName { get; set; }

        /// <summary>
        /// Код проекта
        /// </summary>
        public long? ProjectCode { get; set; }

        /// <summary>
        /// Наименование ТРУ из учетной Системы НП
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Код КПВЭД
        /// </summary>
        [Required]
        public string KpvedCode { get; set; }

        /// <summary>
        /// Код ТНВЭД ЕАЭС
        /// </summary>
        [Required]
        public string TnvedCode { get; set; }

        /// <summary>
        /// Код GTIN
        /// </summary>
        public string GtinCode { get; set; }

        /// <summary>
        /// Сквозной идентификатор товара в пределах НП
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Id единицы измерения
        /// </summary>
        public int MeasureUnitId { get; set; }

        /// <summary>
        /// Код единицы измерения
        /// </summary>
        [Required]
        public string MeasureUnitName { get; set; }

        /// <summary>
        /// Цена за единицу
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// № документа производства/импорта (ДТ, ФНО 328.00, CT-KZ, CT-1)
        /// </summary>
        public string ManufactureOrImportDocNumber { get; set; }

        /// <summary>
        /// Номер товарной позиции из документа импорта (ДТ или ФНО 328.00)
        /// </summary>
        public string ProductNumberInImportDoc { get; set; }

        /// <summary>
        /// Наименование товаров в соответствии с документом импорта (ДТ или ФНО 328.00)
        /// </summary>
        public string ProductNameInImportDoc { get; set; }

        /// <summary>
        /// Физическая метка
        /// </summary>
        public string PhysicalLabel { get; set; }

        /// <summary>
        /// Пин-код
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Крепость (% содержания спирта)
        /// </summary>
        public decimal? SpiritPercent { get; set; }

        /// <summary>
        /// Признак экспортируемости товара: возможен экспорт
        /// </summary>
        public bool CanExport { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Количество товаров в резерве
        /// </summary>
        public decimal? ReserveQuantity { get; set; }
    }
}
