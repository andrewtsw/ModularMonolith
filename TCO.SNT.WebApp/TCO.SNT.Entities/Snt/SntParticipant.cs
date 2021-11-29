using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TCO.SNT.Entities
{
    public abstract class SntParticipant
    {
        public const int TinMaxLen = 50;

        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// ИИН/БИН поставщика/получателя (B 13) (C 22)
        /// </summary>
        [MaxLength(TinMaxLen)]
        public string Tin { get; set; }

        /// <summary>
        /// Нерезидент (B 13.1)  (C 22.1)
        /// </summary>
        public bool NonResident { get; set; }

        /// <summary>
        /// Наименование поставщика/получателя (B 14) (C 23)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// БИН структурного подразделения поставщика/получателя (B 15) (C 24)
        /// </summary>
        public string BranchTin { get; set; }

        /// <summary>
        /// БИН реорганизованного лица (B 16)  (C 25)
        /// </summary>
        public string ReorganizedTin { get; set; }

        /// <summary>
        /// Код страны регистрации поставщика (B 18), Код страны регистрации получателя (C 27)
        /// </summary>
        [Required]
        public string RegisterCountryCode { get; set; }

        /// <summary>
        /// Код страны отправки/отгрузки (B 19) , Код страны доставки/поставки (C 28)
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// Фактический адрес отправки/отгрузки (B 20)
        /// </summary>
        public string ActualAddress { get; set; }

        /// <summary>
        /// Идентификатор склада отправки/отгрузки (B 21) в ИС ЭСФ, Идентификатор склада доставки/поставки (C 30) в ИС ЭСФ
        /// </summary>
        public long? ExternalStoreId { get; set; }

        /// <summary>
        /// Категория поставщика (B 17) / Категория получателя (C 26)
        /// </summary>
        public SntParticipantType[] Statuses { get; set; }

        /// <summary>
        /// Идентификатор склада отправки/отгрузки, доставки/поставки
        /// </summary>
        public int? TaxpayerStoreId { get; set; }

        public virtual TaxpayerStore TaxpayerStore { get; set; }

        public void SetStore(TaxpayerStore store)
        {
            TaxpayerStoreId = store.Id;
            TaxpayerStore = store;
            ExternalStoreId = store.ExternalId;
        }

        public bool IsRelatedToTin(string tin)
        {
            return !string.IsNullOrEmpty(Tin) && Tin == tin;
        }

        public SntParticipantType[] GetStatusesOrEmpty() => Statuses ?? new SntParticipantType[0];

        public void Compare(string prefix, SntParticipant participant, List<KeyValuePair<string, string[]>> validationResult)
        {
            if (Tin != participant.Tin)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.Tin", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (NonResident != participant.NonResident)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.NonResident", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (Name != participant.Name)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.Name", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (BranchTin != participant.BranchTin)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.BranchTin", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (ReorganizedTin != participant.ReorganizedTin)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.ReorganizedTin", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (RegisterCountryCode != participant.RegisterCountryCode)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.RegisterCountryCode", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (CountryCode != participant.CountryCode)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.CountryCode", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (ActualAddress != participant.ActualAddress)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.ActualAddress", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (TaxpayerStoreId != participant.TaxpayerStoreId)
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.TaxpayerStoreId", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (!GetStatusesOrEmpty().SequenceEqual(participant.GetStatusesOrEmpty()))
            {
                validationResult.Add(new KeyValuePair<string, string[]>($"{prefix}.Statuses", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
        }

    }
}
