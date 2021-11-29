namespace TCO.SNT.Infrastructure.Interfaces
{
    public enum SntFilterType
    {
        /// <summary>
        /// Первичная СНТ
        /// </summary>
        PRIMARY_SNT,

        /// <summary>
        /// СНТ на возврат
        /// </summary>
        RETURNED_SNT,

        /// <summary>
        /// Исправленная СНТ
        /// </summary>
        FIXED_SNT,

        /// <summary>
        /// Вывоз товаров
        /// </summary>
        EXPORT_SNT,

        /// <summary>
        /// Перемещение
        /// </summary>
        TRANSFER_SNT,

        /// <summary>
        /// Бумажная СНТ
        /// </summary>
        IS_PAPER_SNT
    }
}
