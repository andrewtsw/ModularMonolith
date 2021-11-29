namespace TCO.SNT.Entities
{
    /// <summary>
    /// Типы детализации для Формы Детализации
    /// </summary>
    public enum UFormDetailingType
    {
        /// <summary>
        /// Конвертация между разными единицами измерения
        /// </summary>
        CONVERSION,

        /// <summary>
        /// Комплектация
        /// </summary>
        PACKING,

        /// <summary>
        /// Разукомплектация
        /// </summary>
        UNPACKING,

        /// <summary>
        /// Пересортица
        /// </summary>
        RE_SORTING,

        /// <summary>
        /// Редактирование данных
        /// </summary>
        EDITING,
    }
}
