using System;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Товар (работа, услуга)
    /// </summary>
    public class InvoiceProduct : EntityBase
    {
        public const string ManuallyEntered = "1";

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Номер продукта (товара, услуги) из СНТ (G 1)
        /// </summary>
        public string ProductNumberInSnt { get; set; }

        /// <summary>
        /// Признак происхождения ТРУ (G 2)
        /// </summary>
        public string TruOriginCode { get; set; }

        /// <summary>
        /// Наименование ТРУ (G 3)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Наименование товаров по классификатору ТН ВЭД ЕАЭС (G 3/1)
        /// </summary>
        public string TnvedName { get; set; }

        /// <summary>
        /// Код товара (ТНВД ЕАЭС) (G 4)
        /// </summary>
        public string UnitCode { get; set; }

        /// <summary>
        /// Ед.изм (G 5)
        /// </summary>
        public string UnitNomenclature { get; set; }

        /// <summary>
        /// Кол-во (объем) (G 6)
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Цена (тариф) за единицу ТРУ без косвенных налогов (G 7)
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Стоимость ТРУ без косвенных налогов (G 8)
        /// </summary>
        public decimal PriceWithoutTax { get; set; }

        /// <summary>
        /// Акциз-Ставка (G 9)
        /// </summary>
        public decimal? ExciseRate { get; set; }

        /// <summary>
        /// Акциз-Сумма (G 10)
        /// </summary>
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// Размер оборота по реализации (облагаемый/необлагаемый оборот) (G 11)
        /// </summary>
        public decimal TurnoverSize { get; set; }

        /// <summary>
        /// Основание корректировки оборота (G 11/1)
        /// </summary>
        public int? TurnoverAdjustment { get; set; }

        /// <summary>
        /// НДС-Ставка (G 12)
        /// </summary>
        public int? NdsRate { get; set; }

        /// <summary>
        /// НДС-Сумма (G 13)
        /// </summary>
        public decimal? NdsAmount { get; set; }

        /// <summary>
        /// Оборот по реализации (G 14)
        /// </summary>
        public string TurnoverCode { get; set; }

        /// <summary>
        /// Стоимость ТРУ с учетом НДС (G 15)
        /// </summary>
        public decimal PriceWithTax { get; set; }

        /// <summary>
        /// Декларации на товары, заявления в рамках ТС, СТ-1 или СТ-KZ (G 16)
        /// </summary>
        public string ProductDeclaration { get; set; }

        /// <summary>
        /// Номер товарной позиции из заявления в рамках ТС или Декларации на товары (G 17)
        /// </summary>
        public string ProductNumberInDeclaration { get; set; }

        /// <summary>
        /// Идентификатор товара, работ, услуг (G 18)
        /// </summary>
        public string CatalogTruId { get; set; }

        /// <summary>
        /// Классификатор продукции по видам экономической деятельности
        /// </summary>
        public string KpvedCode { get; set; }

        /// <summary>
        /// Дополнительные данные (G 19)
        /// </summary>
        public string Additional { get; set; }

        /// <summary>
        /// Дополнительная единица измерения (G 20)
        /// </summary>
        public string AdditionalUnitNomenclature { get; set; }

        public int? MeasureUnitId { get; private set; }
        public MeasureUnit MeasureUnit { get; private set; }

        public void FillCalculatedProperties()
        {
            PriceWithoutTax = UnitPrice.GetValueOrDefault(0m) * Quantity.GetValueOrDefault(0m);
            TurnoverSize = PriceWithoutTax + ExciseAmount.GetValueOrDefault(0m);
            if (NdsRate.HasValue)
                NdsAmount = NdsRate.Value / 100m  * TurnoverSize;
            PriceWithTax = TurnoverSize + (NdsAmount ?? 0m);
        }

        public void SetMeasureUnit(MeasureUnit unit)
        {
            MeasureUnitId = unit.Id;
            MeasureUnit = unit;
            UnitNomenclature = unit.Code;
        }

        public void SetCatalogTruId()
        {
            CatalogTruId = ManuallyEntered;
        }
    }
}
