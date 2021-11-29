using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Validation;
using TCO.SNT.Entities;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.UseCases.UForms.Commands.Dto
{
    public abstract class UFormDtoBase: IValidatableObject
    {
        /// <summary>
        /// Идентификатор существующей формы или null для новой формы
        /// </summary>
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }

        /// <summary>
        /// Дата выписки Универсальной Формы
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime Date { get; set; }

        /// <summary>
        /// Timezone offset from the client in minutes
        /// </summary>
        [Range(-14 * 60, 14 * 60)]
        public int LocalTimezoneOffsetMinutes { get; set; }

        /// <summary>
        /// Исходящий номер Универсальной Формы в бухгалтерии отправителя
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Id склада отправилетя
        /// </summary>
        [Range(1, int.MaxValue)]
        public int SenderTaxpayerStoreId { get; set; }

        public abstract UFormType GetUFormType();

        public abstract IEnumerable<UFormProductDtoBase> GetProducts();

        public virtual void FillForm(UForm form)
        {
            form.Date = Date;
            form.Number = Number;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dateTimeService = (IDateTime)validationContext.GetService(typeof(IDateTime));
            var serverTime = dateTimeService.UtcNow.SetDateWithOffset(LocalTimezoneOffsetMinutes);

            if (Date > serverTime)
            {
                yield return new ValidationResult($"Поля {nameof(Date)} не должна быть в будущем");
            }
        }
    }
}
