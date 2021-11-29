namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    public class InvoiceProductDto
    {
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
        public string UnitCode { get; set; }

        /// <summary>
        /// Ед.изм (G 5)
        /// </summary>
        public int MeasureUnitId { get; set; }

        /// <summary>
        /// Кол-во (объем) (G 6)
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Цена (тариф) за единицу ТРУ без косвенных налогов (G 7)
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Акциз-Ставка (G 9)
        /// </summary>
        public decimal? ExciseRate { get; set; }

        /// <summary>
        /// Акциз-Сумма (G 10)
        /// </summary>
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// НДС-Ставка (G 12)
        /// </summary>
        public int? NdsRate { get; set; }

        /// <summary>
        /// Декларации на товары, заявления в рамках ТС, СТ-1 или СТ-KZ (G 16)
        /// </summary>
        public string ProductDeclaration { get; set; }

        /// <summary>
        /// Номер товарной позиции из заявления в рамках ТС или Декларации на товары (G 17)
        /// </summary>
        public string ProductNumberInDeclaration { get; set; }

        /// <summary>
        /// Дополнительные данные (G 19)
        /// </summary>
        public string Additional { get; set; }
    }
}
