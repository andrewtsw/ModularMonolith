using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Validation;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    /// <summary>
    /// Условия поставки (E)
    /// </summary>
    public class InvoiceDeliveryTermDto : IValidatableObject
    {
        /// <summary>
        /// Договор/без договора (E 27.1 - true, E27.2 - false)
        /// </summary>
        public bool HasContract { get; set; }

        /// <summary>
        /// Номер договора(контракт) на поставку товаров (работ, услуг) (E 27.3)
        /// </summary>
        public string ContractNum { get; set; }

        /// <summary>
        /// Дата договора(контракт) на поставку товаров (работ, услуг) (E 27.4)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? ContractDate { get; set; }

        /// <summary>
        /// Условия оплаты по договору (E 28)
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Способ отправления (E 29)
        /// </summary>
        public string TransportTypeCode { get; set; }

        /// <summary>
        /// Доверенность/Без доверенности
        /// </summary>
        public bool HasWarrant { get; set; }

        /// <summary>
        /// Номер доверенности на поставку товаров (работ, услуг) (E 30.1)
        /// </summary>
        public string Warrant { get; set; }

        /// <summary>
        /// Дата доверенности на поставку товаров (работ, услуг) (E 30.2)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? WarrantDate { get; set; }

        /// <summary>
        /// Пункт назначения поставляемых товаров (работ, услуг) (E 31)
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Условия поставки (E 31.1)
        /// </summary>
        public string DeliveryConditionCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HasContract)
            {
                if (ContractDate == null)
                    yield return new ValidationResult($"{nameof(ContractDate)} must not be null when {nameof(HasContract)} specified", new[] { nameof(ContractDate) });
                if (string.IsNullOrEmpty(ContractNum))
                    yield return new ValidationResult($"{nameof(ContractNum)} must not be null when {nameof(HasContract)} specified", new[] { nameof(ContractNum) });
            }
            else
            {
                if (ContractDate != null)
                    yield return new ValidationResult($"{nameof(ContractDate)} must be null when {nameof(HasContract)} not specified", new[] { nameof(ContractDate) });
                if (!string.IsNullOrEmpty(ContractNum))
                    yield return new ValidationResult($"{nameof(ContractNum)} must be null when {nameof(HasContract)} not specified", new[] { nameof(ContractNum) });
            }

            if (HasWarrant)
            {
                if (WarrantDate == null)
                    yield return new ValidationResult($"{nameof(WarrantDate)} must not be null when {nameof(HasWarrant)} specified", new[] { nameof(WarrantDate) });
                if (string.IsNullOrEmpty(Warrant))
                    yield return new ValidationResult($"{nameof(Warrant)} must not be null when {nameof(HasWarrant)} specified", new[] { nameof(Warrant) });
            }
            else
            {
                if (WarrantDate != null)
                    yield return new ValidationResult($"{nameof(WarrantDate)} must be null when {nameof(HasWarrant)} not specified", new[] { nameof(WarrantDate) });
                if (!string.IsNullOrEmpty(Warrant))
                    yield return new ValidationResult($"{nameof(Warrant)} must be null when {nameof(HasWarrant)} not specified", new[] { nameof(Warrant) });
            }
        }
    }
}
