namespace TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus
{
    /// <summary>
    /// Запрос на отзыв СНТ
    /// </summary>
    public class RevokeSntDto
    {
        /// <summary>
        /// Идентификатор СНТ
        /// </summary>
        public int SntId { get; set; }

        /// <summary>
        /// Причина отзыва
        /// </summary>
        public string Cause { get; set; }
    }
}
