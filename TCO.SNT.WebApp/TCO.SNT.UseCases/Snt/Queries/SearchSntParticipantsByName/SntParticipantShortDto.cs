using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Snt.Queries.SearchSntParticipantsByName
{
    public class SntParticipantShortDto
    {
        /// <summary>
        /// Фактический адрес доставки/поставки (B 20, C 29)
        /// </summary>
        public string ActualAddress { get; set; }

        /// <summary>
        /// Код страны доставки/поставки (B 19, C 28)
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// Нерезидент (B 13.1, C 22.1)
        /// </summary>
        public bool NonResident { get; set; }

        /// <summary>
        /// Код страны регистрации получателя (B 18, C 27)
        /// </summary>
        [Required]
        public string RegisterCountryCode { get; set; }

        /// <summary>
        /// БИН реорганизованного лица (B 16, C 25)
        /// </summary>
        public string ReorganizedTin { get; set; }

        /// <summary>
        /// Категория поставщика (B 17) / Категория получателя (C 26) 
        /// </summary>
        public SntParticipantType[] Statuses { get; set; }

        /// <summary>
        /// БИН структурного подразделения поставщика/получателя (B 15, C 24)
        /// </summary>
        public string BranchTin { get; set; }

        /// <summary>
        /// Наименование поставщика/получателя (B 14, C 23)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// ИИН/БИН поставщика/получателя (B 13, C 22)
        /// </summary>
        public string Tin { get; set; }
    }

}
