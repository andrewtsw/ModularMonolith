using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Грузополучатель (D)
    /// </summary>
    public class SntConsignee
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// ИИН/БИН (D 34)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// Нерезидент (D 34.1)
        /// </summary>
        public bool NonResident { get; set; }

        /// <summary>
        /// Наименование грузополучателя (D 35)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Код страны доставки (D 36)
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// Дополнительные сведения (D1 b)
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
