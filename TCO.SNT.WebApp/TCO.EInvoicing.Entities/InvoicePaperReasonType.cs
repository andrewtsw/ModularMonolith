namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Причина выписки на бумажном носителе (2.1)
    /// </summary>
    public enum InvoicePaperReasonType
    {
        /// <summary>
        /// Простой системы
        /// </summary>
        DOWN_TIME,

        /// <summary>
        /// Отсутствовало требование по выписке ЭСФ
        /// </summary>
        MISSING_REQUIREMENT,

        /// <summary>
        /// Неправомерное снятие с регистрационного учета
        /// </summary>
        UNLAWFUL_REMOVAL_REGISTRATION,
    }
}
