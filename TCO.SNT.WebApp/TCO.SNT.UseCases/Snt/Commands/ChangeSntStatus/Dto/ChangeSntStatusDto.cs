namespace TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus
{
    /// <summary>
    /// DTO для изменения статуса СНТ
    /// </summary>
    public class ChangeSntStatusDto
    {
        /// <summary>
        /// Идентефикатор СНТ в нашей системе
        /// </summary>
        public int SntId { get; set; }

        /// <summary>
        /// Подпись исходной СНТ
        /// </summary>
        public string OriginalDocumentSignature { get; set; }

        /// <summary>
        /// Дата документа доверенности приемки товара
        /// </summary>
        public string PowerOfAttorneyDate { get; set; }

        /// <summary>
        /// Номер документа доверенности приемки товара
        /// </summary>
        public string PowerOfAttorneyNumber { get; set; }

        /// <summary>
        /// Причина отзыва
        /// </summary>
        public string Cause { get; set; }
    }
}
