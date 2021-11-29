namespace TCO.SNT.UseCases.GroupTaxpayerStores.Queries
{
    public class TaxpayerStoreDescriptionDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор в ЕСФ
        /// </summary>
        public long ExternalId { get; set; }

        /// <summary>
        /// Наименование склада
        /// </summary>
        public string Name { get; set; }
    }
}
