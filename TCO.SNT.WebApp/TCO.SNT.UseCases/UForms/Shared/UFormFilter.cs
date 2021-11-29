using System;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Validation;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.UForms.Shared
{
    /// <summary>
    /// Фильтр списка универсальных форм
    /// </summary>
    public class UFormFilter
    {
        /// <summary>
        /// Номер документа
        /// </summary>
        [MaxLength(UForm.NumberMaxLen)]
        public string Number { get; set; }

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [MaxLength(UFormInfo.RegistrationNumberMaxLen)]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Дата документа "с" (yyyy-MM-dd format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата документа "по" (yyyy-MM-dd format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// БИН отправителя
        /// </summary>
        [MaxLength(UFormParticipant.TinMaxLen)]
        public string SenderTin { get; set; }

        /// <summary>
        /// БИН получателя
        /// </summary>
        [MaxLength(UFormParticipant.TinMaxLen)]
        public string RecipientTin { get; set; }

        /// <summary>
        /// Общая сумма "с"
        /// </summary>
        public decimal? TotalSumFrom { get; set; }

        /// <summary>
        /// Общая сумма "по"
        /// </summary>
        public decimal? TotalSumTo { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public UFormType? Type { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public UFormStatusType? Status { get; set; }

        /// <summary>
        /// Склад отправителя
        /// </summary>
        public int? SenderStoreId { get; set; }

        /// <summary>
        /// Склад получателя
        /// </summary>
        public int? RecipientStoreId { get; set; }
    }
}
