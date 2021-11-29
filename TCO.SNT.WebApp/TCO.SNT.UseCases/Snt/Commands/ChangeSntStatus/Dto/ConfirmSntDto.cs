using System;
using TCO.SNT.Common.Validation;

namespace TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus
{
    /// <summary>
    /// Запрос на подтверждение СНТ
    /// </summary>
    public class ConfirmSntDto
    {
        /// <summary>
        /// Идентификатор СНТ
        /// </summary>
        public int SntId { get; set; }

        /// <summary>
        /// Дата документа доверенности приемки товара
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime PowerOfAttorneyDate { get; set; }

        /// <summary>
        /// Номер документа доверенности приемки товара
        /// </summary>
        public string PowerOfAttorneyNumber { get; set; }
    }
}
