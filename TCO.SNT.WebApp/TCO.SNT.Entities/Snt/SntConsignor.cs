using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Грузоотправитель (D)
    /// </summary>
    public class SntConsignor
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// ИИН/БИН (D 31)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// Нерезидент (D 31.1)
        /// </summary>
        public bool NonResident { get; set; }

        /// <summary>
        /// Наименование грузоотправителя (D 32)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Код страны отправки (D 33)
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// Дополнительные сведения (D1 a)
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
