namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Тип ЭЦП
    /// </summary>
    public enum InvoiceSignatureType
    {
        /// <summary>
        /// ЭЦП юридического лица
        /// </summary>
        COMPANY,

        /// <summary>
        /// ЭЦП лица, уполномоченного подписывать счета-фактуры
        /// </summary>
        OPERATOR
    }
}
