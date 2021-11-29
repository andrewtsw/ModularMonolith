namespace TCO.EInvoicing.Entities
{
    public enum AwpStatus
    {
        /// <summary>
        /// Черновик
        /// </summary>
        DRAFT,

        /// <summary>
        /// Не просмотрен
        /// </summary>
        NOT_VIEWED,

        /// <summary>
        /// Доставленный
        /// </summary>
        DELIVERED,

        /// <summary>
        /// Созданный
        /// </summary>
        CREATED,

        /// <summary>
        /// Черновик импортирован
        /// </summary>
        IMPORTED,

        /// <summary>
        /// Ошибочный
        /// </summary>
        FAILED,

        /// <summary>
        /// Подтвержден
        /// </summary>
        CONFIRMED,

        /// <summary>
        /// Отклонен
        /// </summary>
        DECLINED,

        /// <summary>
        /// Отозван
        /// </summary>
        REVOKED,

        /// <summary>
        /// В процессе расторжения
        /// </summary>
        IN_TERMINATING,

        /// <summary>
        /// Расторгнут
        /// </summary>
        TERMINATED,
    }
}
