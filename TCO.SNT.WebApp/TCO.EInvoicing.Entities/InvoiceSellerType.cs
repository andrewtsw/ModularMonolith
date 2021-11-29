namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Тип поставщика (B 10)
    /// </summary>
    public enum InvoiceSellerType
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
        /// Экспедитор
        /// </summary>
        FORWARDER,

        /// <summary>
        /// Лизингодатель
        /// </summary>
        LESSOR,

        /// <summary>
        /// Участник договора совместной деятельности
        /// </summary>
        JOINT_ACTIVITY_PARTICIPANT,

        /// <summary>
        /// Участник СРП или сделки, заключенной в рамках СРП
        /// </summary>
        SHARING_AGREEMENT_PARTICIPANT,

        /// <summary>
        /// Экспортёр
        /// </summary>
        EXPORTER,

        /// <summary>
        /// Международный перевозчик
        /// </summary>
        TRANSPORTER,

        /// <summary>
        /// Доверитель
        /// </summary>
        PRINCIPAL,

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
