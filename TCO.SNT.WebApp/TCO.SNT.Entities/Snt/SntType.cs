namespace TCO.SNT.Entities
{
    /// <summary>
    /// Тип СНТ
    /// </summary>
    public enum SntType
    {
        /// <summary>
        /// Первичная
        /// </summary>
        PRIMARY_SNT,

        /// <summary>
        /// На возврат товаров
        /// </summary>
        RETURNED_SNT,

        /// <summary>
        /// Исправленная (аннулированная, отклоненная)
        /// </summary>
        FIXED_SNT,
    }
}
