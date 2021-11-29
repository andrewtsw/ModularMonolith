namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Статус ЭСФ в системе
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// В очереди
        /// </summary>
        IN_QUEUE,

        /// <summary>
        /// В обработке
        /// </summary>
        IN_PROCESSING,

        /// <summary>
        /// Созданный
        /// </summary>
        CREATED,

        /// <summary>
        /// Доставленный
        /// </summary>
        DELIVERED,

        /// <summary>
        /// Аннулированный
        /// </summary>
        CANCELED,

        /// <summary>
        /// Аннулирован ИС ЭСФ для отнесения в зачет и на вычеты
        /// </summary>
        CANCELED_BY_OGD,

        /// <summary>
        /// Аннулирован при отклонении СНТ
        /// </summary>
        CANCELED_BY_SNT_DECLINE,

        /// <summary>
        /// Аннулирован при отзыве СНТ
        /// </summary>
        CANCELED_BY_SNT_REVOKE,

        /// <summary>
        /// Отозванный
        /// </summary>
        REVOKED,

        /// <summary>
        /// Импортированный
        /// </summary>
        IMPORTED,

        /// <summary>
        /// Черновик
        /// </summary>
        DRAFT,

        /// <summary>
        /// Ошибочный
        /// </summary>
        FAILED,

        /// <summary>
        /// Удаленный
        /// </summary>
        DELETED,

        /// <summary>
        /// Отклоненный
        /// </summary>
        DECLINED
    }
}
