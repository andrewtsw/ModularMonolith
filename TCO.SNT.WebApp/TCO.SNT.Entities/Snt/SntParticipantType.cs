namespace TCO.SNT.Entities
{
    /// <summary>
    /// Категория поставщика (B 17) и получателя (C 26)
    /// </summary>
    public enum SntParticipantType
    {
        /// <summary>
        /// Адвокат
        /// </summary>
        LAWYER,

        /// <summary>
        /// Нотариус
        /// </summary>
        NOTARY,

        /// <summary>
        /// Медиатор (Посредник)
        /// </summary>
        MEDIATOR,

        /// <summary>
        /// Частный судебный исполнитель
        /// </summary>
        BAILIFF,

        /// <summary>
        /// Физическое лицо
        /// </summary>
        INDIVIDUAL,

        /// <summary>
        /// Розничная реализация
        /// </summary>
        RETAIL,

        /// <summary>
        /// Розничный реализатор
        /// </summary>
        RETAILER,

        /// <summary>
        /// Фармацевтический производитель
        /// </summary>
        PHARMACEUTIC_PRODUCER,

        /// <summary>
        /// Лизингополучатель
        /// </summary>
        LESSEE,

        /// <summary>
        /// Лизингодатель
        /// </summary>
        LESSOR,

        /// <summary>
        /// Доверитель
        /// </summary>
        PRINCIPAL,

        /// <summary>
        /// Комитент
        /// </summary>
        COMMITTENT,

        /// <summary>
        /// Комиссионер
        /// </summary>
        BROKER,

        /// <summary>
        /// Участник СРП или сделки, заключенной в рамках СРП
        /// </summary>
        SHARING_AGREEMENT_PARTICIPANT,

        /// <summary>
        /// Участник договора совместной деятельности
        /// </summary>
        JOINT_ACTIVITY_PARTICIPANT
    }
}
