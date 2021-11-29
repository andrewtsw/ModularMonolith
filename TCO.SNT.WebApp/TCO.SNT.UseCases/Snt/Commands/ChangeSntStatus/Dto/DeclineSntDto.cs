namespace TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus
{
    /// <summary>
    /// Запрос на отклонение СНТ
    /// </summary>
    public class DeclineSntDto
    {
        /// <summary>
        /// Идентификатор СНТ
        /// </summary>
        public int SntId { get; set; }

        /// <summary>
        /// Причина отклонения
        /// </summary>
        public string Cause { get; set; }
    }
}
