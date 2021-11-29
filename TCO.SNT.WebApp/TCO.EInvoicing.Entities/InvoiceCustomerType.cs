namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Тип получателя (C 22)
    /// </summary>
    public enum InvoiceCustomerType
    {

        /// <summary>
        /// Комитент
        /// </summary>
        COMMITTENT,

        /// <summary>
        /// Комиссионер
        /// </summary>
        BROKER,

        /// <summary>
        /// Лизингополучатель
        /// </summary>
        LESSEE,

        /// <summary>
        /// Участник договора совместной деятельности
        /// </summary>
        JOINT_ACTIVITY_PARTICIPANT,

        /// <summary>
        /// Государственное учреждение
        /// </summary>
        PUBLIC_OFFICE,

        /// <summary>
        /// Нерезидент
        /// </summary>
        NONRESIDENT,

        /// <summary>
        /// Участник СРП или сделки, заключенной в рамках СРП
        /// </summary>
        SHARING_AGREEMENT_PARTICIPANT,

        /// <summary>
        /// Доверитель
        /// </summary>
        PRINCIPAL,

        /// <summary>
        /// Розничная реализация
        /// </summary>
        RETAIL,

        /// <summary>
        /// Физическое лицо
        /// </summary>
        INDIVIDUAL,

        /// <summary>
        /// Адвокат
        /// </summary>
        LAWYER,

        /// <summary>
        /// Частный судебный исполнитель
        /// </summary>
        BAILIFF,

        /// <summary>
        /// Медиатор
        /// </summary>
        MEDIATOR,

        /// <summary>
        /// Нотариус
        /// </summary>
        NOTARY
    }
}
