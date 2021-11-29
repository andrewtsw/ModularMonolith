using System;
using TCO.SNT.Common.Errors;
using TCO.SNT.Entities;

namespace TCO.SNT.Infrastructure.Interfaces
{
    /// <summary>
    /// Универсальная форма для отчета
    /// </summary>
    public class UFormReport : IWithError
    {
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
        /// Локализованный тип универсальной формы
        /// </summary>
        public string LocalizedType { get; set; }

        /// <summary>
        /// Исходящий номер Универсальной Формы в бухгалтерии отправителя
        /// </summary>        
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
        /// Локализованный статус универсальной формы в системе
        /// </summary>
        public string LocalizedStatus { get; set; }

        /// <summary>
        /// Причина аннулирования
        /// </summary>
        public string CancelReason { get; set; }

        #region IWithError

        public string ErrorCode => CancelReason;

        public void SetErrorDescription(string description) => CancelReason = description;

        #endregion
    }
}