namespace TCO.SNT.Entities
{
    /// <summary>
    /// Тип универсальной формы
    /// </summary>
    public enum UFormType
    {
        /// <summary>
        /// ЭСФ
        /// </summary>
        ESF,

        /// <summary>
        /// Чек ККМ
        /// </summary>
        KKM,

        /// <summary>
        /// ДТ - Декларация на товары
        /// </summary>
        DT,

        /// <summary>
        /// ФНО 328.00 - Форма налоговой отчетности
        /// </summary>
        FNO,

        /// <summary>
        /// Форма Производства
        /// </summary>
        MANUFACTURE,

        /// <summary>
        /// Форма ввода Остатков
        /// </summary>
        BALANCE,

        /// <summary>
        /// Форма Внутреннего перемещения
        /// </summary>
        MOVEMENT,

        /// <summary>
        /// Форма Списания
        /// </summary>
        WRITE_OFF,

        /// <summary>
        /// Форма Корректировки остатков
        /// </summary>
        BALANCE_CORRECTION,

        /// <summary>
        /// Форма Детализации (различаются 4 вида)
        /// </summary>
        DETAILING,

        /// <summary>
        /// Форма Ввода физических меток
        /// </summary>
        PHYSICAL_LABEL,

        /// <summary>
        /// Форма Реорганизации
        /// </summary>
        REORGANIZATION,

        /// <summary>
        /// Форма Детализации Импорта
        /// </summary>
        IMPORT_DETAILING,
    }
}
