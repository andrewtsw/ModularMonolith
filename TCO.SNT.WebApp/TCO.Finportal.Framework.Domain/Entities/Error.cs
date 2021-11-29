namespace TCO.Finportal.Framework.Domain.Entities
{
    /// <summary>
    /// Объект содержащий ошибки валидации документа
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Поле документа, в котором обнаружена ошибка
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        public string Text { get; set; }
    }
}
