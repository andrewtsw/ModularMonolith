using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.UseCases.Snt.Shared
{
    public class SntConsignmentParticipantDto
    {
        /// <summary>
        /// ИИН/БИН (D 31, D 34)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// Нерезидент (D 31.1, D 34.1)
        /// </summary>
        public bool NonResident { get; set; }

        /// <summary>
        /// Наименование грузоотправителя/грузополучателя (D 32, D 35)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Код страны отправки/доставки (D 33, D 36)
        /// </summary>
        [Required]
        public string CountryCode { get; set; }
    }
}
