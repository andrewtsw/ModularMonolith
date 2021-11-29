using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Остаток партии товара на виртуальном складе
    /// </summary>
    public class Balance : EntityBase
    {
        public const int NameMaxLen = 450;

        /// <summary>
        /// ИИН/БИН НП
        /// </summary>
        [Required]
        public string Tin { get; private set; }

        /// <summary>
        /// Id склада во внешней системе
        /// </summary>
        public long ExternalTaxpayerStoreId { get; private set; }

        public int TaxpayerStoreId { get; private set; }
        public TaxpayerStore TaxpayerStore { get; private set; }

        public void SetTaxpayerStore(TaxpayerStore store)
        {
            TaxpayerStore = store;
            TaxpayerStoreId = store.Id;
            ExternalTaxpayerStoreId = store.ExternalId;
        }

        /// <summary>
        /// Код проекта
        /// </summary>
        public long? ProjectCode { get; private set; }

        /// <summary>
        /// Наименование ТРУ из учетной Системы НП
        /// </summary>
        [Required]
        [MaxLength(NameMaxLen)]
        public string Name { get; private set; }

        /// <summary>
        /// Код КПВЭД
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string KpvedCode { get; private set; }

        /// <summary>
        /// Код ТНВЭД ЕАЭС
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string TnvedCode { get; private set; }

        /// <summary>
        /// Код GTIN
        /// </summary>
        [MaxLength(450)]
        public string GtinCode { get; private set; }

        /// <summary>
        /// Сквозной идентификатор товара в пределах НП
        /// </summary>
        public long ProductId { get; private set; }

        /// <summary>
        /// Код единицы измерения
        /// </summary>
        [Required]
        public string ExternalMeasureUnitCode { get; private set; }

        public int MeasureUnitId { get; private set; }
        public MeasureUnit MeasureUnit { get; private set; }

        public void SetMeasureUnitLink(MeasureUnit measureUnit)
        {
            MeasureUnitId = measureUnit.Id;
            ExternalMeasureUnitCode = measureUnit.Code;
        }

        /// <summary>
        /// Цена за единицу
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// № документа производства/импорта (ДТ, ФНО 328.00, CT-KZ, CT-1)
        /// </summary>
        public string ManufactureOrImportDocNumber { get; private set; }

        /// <summary>
        /// Номер товарной позиции из документа импорта (ДТ или ФНО 328.00)
        /// </summary>
        public string ProductNumberInImportDoc { get; private set; }

        /// <summary>
        /// Наименование товаров в соответствии с документом импорта (ДТ или ФНО 328.00)
        /// </summary>
        public string ProductNameInImportDoc { get; private set; }

        /// <summary>
        /// Физическая метка
        /// </summary>
        public string PhysicalLabel { get; private set; }

        /// <summary>
        /// Пин-код
        /// </summary>
        public string PinCode { get; private set; }

        /// <summary>
        /// Крепость (% содержания спирта)
        /// </summary>
        public decimal? SpiritPercent { get; private set; }

        /// <summary>
        /// Признак экспортируемости товара: возможен экспорт
        /// </summary>
        public bool CanExport { get; private set; }

        /// <summary>
        /// Количество
        /// </summary>
        public decimal Quantity { get; private set; }

        /// <summary>
        /// Количество товаров в резерве
        /// </summary>
        public decimal? ReserveQuantity { get; private set; }

        public bool IsActive { get; private set; }

        /// <summary>
        /// Тип пошлины
        /// </summary>
        public BalanceDutyType? DutyType { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        [MaxLength(5)]
        public string CountryCode { get; set; }

        public static Balance CreateActive() => new Balance { IsActive = true };

        public string GetFullProductCode()
        {
            var code = $"{KpvedCode}-{TnvedCode}";
            if (!string.IsNullOrEmpty(GtinCode))
            {
                code += $"/{GtinCode}";
            }
            return code;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void UpdateQuantities(decimal quantity, decimal? reserveQuantity)
        {
            Quantity = quantity;
            ReserveQuantity = reserveQuantity;
        }

        public void UpdatePropertiesNotFromTheKey(long? projectCode, bool canExport)
        {
            ProjectCode = projectCode;
            CanExport = canExport;
        }
    }
}
