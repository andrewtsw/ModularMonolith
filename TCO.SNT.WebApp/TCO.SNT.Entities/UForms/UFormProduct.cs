using System;
using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Товар Универсальной Формы
    /// </summary>
    public class UFormProduct : EntityBase
    {
        public int? ProductFormId { get; private set; }
        public UForm ProductForm { get; private set; }

        public int? SourceProductFormId { get; private set; }
        public UForm SourceProductForm { get; private set; }

        #region AbstractUFormProduct fields

        /// <summary>
        /// Выбирается товар типа TNVED или GTIN
        /// </summary>
        [Required]
        public string ExternalGsvsCode { get; set; }

        /// <summary>
        /// Ссылка на товар из ГСВС в нашей системе
        /// </summary>
        public int? ProductId { get; private set; }
        public Product Product { get; private set; }

        public void SetProduct(Product product)
        {
            Product = product;
            ProductId = product.Id;
        }

        public void FillProduct(Product product)
        {
            if (!product.IsAvailableForSnt())
            {
                //TODO: use validation exception
                throw new InvalidOperationException("Only TNVED or GTIN products availbale in form products.");
            }
            SetProduct(product);
        }

        /// <summary>
        /// Единица измерения
        /// </summary>
        [Required]
        public string ExternalMeasureUnitCode { get; set; }

        public int MeasureUnitId { get; private set; }
        public MeasureUnit MeasureUnit { get; private set; }

        public void SetMeasureUnit(MeasureUnit measureUnit)
        {
            MeasureUnit = measureUnit;
            MeasureUnitId = measureUnit.Id;
        }

        public void FillMeasureUnit(MeasureUnit measureUnit)
        {
            SetMeasureUnit(measureUnit);
            ExternalMeasureUnitCode = measureUnit.Code;
        }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }

        #endregion

        #region UFormProduct fields

        /// <summary>
        /// Возможен экспорт
        /// </summary>
        public bool? CanExport { get; set; }

        /// <summary>
        /// Тип пошлины
        /// </summary>
        public UFormCustomsDutyType? DutyTypeCode { get; set; }

        /// <summary>
        /// Страна импорта/производства
        /// </summary>
        public string ManufactureOrImportCountry { get; set; }

        /// <summary>
        /// Номер документа производства или импорта (№ ДТ, ФНО 328.00, CT-KZ, CT-1)
        /// </summary>
        public string ManufactureOrImportDocNumber { get; set; }

        /// <summary>
        /// Код маркировки (GTIN)
        /// </summary>
        public string MarkingCode { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Дата сертификата происхождения
        /// </summary>
        public string OriginCertificateDate { get; set; }

        /// <summary>
        /// Признак происхождения товаров, работ, услуг
        /// </summary>
        public string OriginCode { get; set; }

        /// <summary>
        /// Физическая метка
        /// </summary>
        public string PhysicalLabel { get; set; }

        /// <summary>
        /// Пин-код
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Партия товара на складе
        /// </summary>
        public long? ExternalProductId { get; set; }

        public int? BalanceId { get; private set; }
        public Balance Balance { get; private set; }

        public void FillBalance(Balance balance)
        {
            SetBalance(balance);
            ExternalProductId = balance.ProductId;
            Name = balance.Name;
            FillMeasureUnit(balance.MeasureUnit);
            SetProductCodes(balance);
        }

        public void SetBalance(Balance balance)
        {
            Balance = balance;
            BalanceId = balance.Id;
        }

        public void SetProductCodes(Product kpved, Product tnved, Product gtin)
        {
            ExternalGsvsCode = $"{kpved.Code}-{tnved.Code}";
            if (gtin != null)
            {
                ExternalGsvsCode += $"/{gtin.Code}";
            }
            TnvedCode = tnved.Code;
        }

        public void SetProductCodes(Balance balance)
        {
            ExternalGsvsCode = balance.GetFullProductCode();
            TnvedCode = balance.TnvedCode;
        }

        /// <summary>
        /// Наименование товаров в соответствии с документом импорта (ДТ или ФНО 328.00)
        /// </summary>
        public string ProductNameInImportDoc { get; set; }

        /// <summary>
        /// Номер товарной позиции из документа импорта (ДТ или ФНО 328.00)
        /// </summary>
        public string ProductNumberInImportDoc { get; set; }

        /// <summary>
        /// Крепость (% содержания спирта)
        /// </summary>
        public decimal? SpiritPercent { get; set; }

        /// <summary>
        /// Код ТН ВЭД ЕАЭС
        /// </summary>
        [Required]
        public string TnvedCode { get; set; }

        #endregion

        public decimal CalculateTotal()
        {
            Sum = Price * Quantity;
            // Sum should be rounded to 2 decimal places
            return Sum = decimal.Round(Sum, 2, MidpointRounding.AwayFromZero);
        }
    }
}
