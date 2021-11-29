namespace TCO.SNT.Entities
{
    /// <summary>
    /// Ввоз товаров на территорию РК (A 7)
    /// </summary>
    public enum SntImportType
    {
        /// <summary>
        /// Ввоз товаров на территорию РК (Импорт) (A 7.1)
        /// </summary>
        IMPORT,

        /// <summary>
        /// Ввоз на переработку (A 7.2)
        /// </summary>
        IMPORT_FOR_PROCESSING,

        /// <summary>
        /// Временный ввоз (A 7.3)
        /// </summary>
        TEMPORARY_IMPORT,

        /// <summary>
        /// Ввоз временно вывезенного товара (A 7.4)
        /// </summary>
        IMPORT_OF_TEMPORARY_EXPORTED_PRODUCT,

        /// <summary>
        /// Ввоз товаров на территорию СЭЗ (A 7.5)
        /// </summary>
        IMPORT_IN_SEZ
    }
}
