namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Тип ЭСФ
    /// </summary>
    public enum InvoiceType
    {
        /// <summary>
        /// Основной ЭСФ
        /// </summary>
        ORDINARY_INVOICE,

        /// <summary>
        /// Исправленный ЭСФ (A 4)
        /// </summary>
        FIXED_INVOICE,

        /// <summary>
        /// Дополнительный ЭСФ (A 5)
        /// </summary>
        ADDITIONAL_INVOICE,
    }
}
