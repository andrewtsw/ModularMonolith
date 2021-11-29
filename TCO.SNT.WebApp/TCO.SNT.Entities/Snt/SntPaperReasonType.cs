namespace TCO.SNT.Entities
{
    /// <summary>
    /// Причина выписки на бумажном носителе (2.1)
    /// </summary>
    public enum SntPaperReasonType
    {
        /// <summary>
        /// Простой системы или плановые работы
        /// </summary>
        DOWN_TIME,

        /// <summary>
        /// Блокировка уполномоченным органом
        /// </summary>
        UNLAWFUL_REMOVAL_REGISTRATION,

        /// <summary>
        /// Отсутствовало требование по выписке
        /// </summary>
        MISSING_REQUIREMENT
    }
}
