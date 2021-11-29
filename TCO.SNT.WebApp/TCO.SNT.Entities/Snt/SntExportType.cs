namespace TCO.SNT.Entities
{
    /// <summary>
    /// Вывоз товаров с территории РК (A 8)
    /// </summary>
    public enum SntExportType
    {
        /// <summary>
        /// Вывоз товаров с территории РК (Экспорт) (A 8.1)
        /// </summary>
        EXPORT,

        /// <summary>
        /// Вывоз на переработку (A 8.2)
        /// </summary>
        EXPORT_FOR_PROCESSING,

        /// <summary>
        /// Временный вывоз (A 8.3)
        /// </summary>
        TEMPORARY_EXPORT,

        /// <summary>
        /// Вывоз временно ввезенного товара (A 8.4)
        /// </summary>
        EXPORT_OF_TEMPORARY_IMPORTED_PRODUCT,

        /// <summary>
        /// Вывоз товаров с территории СЭЗ (A 8.5)
        /// </summary>
        EXPORT_FROM_SEZ,

        /// <summary>
        /// Заправка воздушного судна (A 8.6)
        /// </summary>
        AIRCRAFT_REFUELING
    }
}
