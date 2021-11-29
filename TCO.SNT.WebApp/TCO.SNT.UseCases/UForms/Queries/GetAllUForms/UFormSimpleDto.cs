using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCO.SNT.Common.Errors;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.UForms.Queries.GetAllUForms
{
    /// <summary>
    /// Универсальная форма
    /// </summary>
    public class UFormSimpleDto : IWithError
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор в ЭСФ
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Дата выписки Универсальной Формы
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Тип Универсальной Формы
        /// </summary>
        public UFormType Type { get; set; }

        /// <summary>
        /// Исходящий номер Универсальной Формы в бухгалтерии отправителя
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// ИИН/БИН получателя Универсальной Формы
        /// </summary>
        public string RecipientTin { get; set; }

        /// <summary>
        /// Регистрационный номер Универсальной Формы
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// ИИН/БИН отправителя Универсальной Формы
        /// </summary>
        [Required]
        public string SenderTin { get; set; }

        /// <summary>
        /// Общая сумма
        /// </summary>
        public decimal TotalSum { get; set; }

        /// <summary>
        /// Cтатус Универсальной Формы в системе
        /// </summary>
        public UFormStatusType Status { get; set; }

        /// <summary>
        /// Причина аннулирования
        /// </summary>
        public string CancelReason { get; set; }

        #region IWithError

        [JsonIgnore]
        public string ErrorCode => CancelReason;

        public void SetErrorDescription(string description) => CancelReason = description;

        #endregion
    }
}
