namespace TCO.SNT.Entities
{
    /// <summary>
    /// Статус СНТ
    /// </summary>
    public enum SntStatus
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
        /// Подтвержден инспектором ОГД
        /// </summary>
        CONFIRMED_BY_OGD,

        /// <summary>
        /// Отклонен инспектором ОГД
        /// </summary>
        DECLINED_BY_OGD,

        /// <summary>
        /// Аннулирован
        /// </summary>
        CANCELED,

        /// <summary>
        /// Отозван
        /// </summary>
        REVOKED
    }
}
