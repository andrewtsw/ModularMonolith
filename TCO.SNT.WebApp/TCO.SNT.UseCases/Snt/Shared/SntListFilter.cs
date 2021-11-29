using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Validation;
using TCO.SNT.Entities;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.UseCases.Snt.Shared
{
    /// <summary>
    /// СНТ фильтр
    /// </summary>
    public class SntListFilter : IValidatableObject
    {
        /// <summary>
        /// Дата СНТ "с" (yyyy-MM-dd format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата СНТ "по" (yyyy-MM-dd format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public SntFilterType? Type { get; set; }

        /// <summary>
        /// Тип импорта
        /// </summary>
        public SntImportType? ImportType { get; set; }

        /// <summary>
        /// Тип экспорта
        /// </summary>
        public SntExportType? ExportType { get; set; }

        /// <summary>
        /// Тип транспортировки
        /// </summary>
        public SntTransferType? TransferType { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public SntStatus? Status { get; set; }

        /// <summary>
        /// Дата обновления СНТ "c" (yyyy-MM-ddT00:00Z format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? LastUpdateDateFromUtc { get; set; }

        /// <summary>
        /// Дата обновления СНТ "по" yyyy-MM-ddT00:00Z format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? LastUpdateDateToUtc { get; set; }

        /// <summary>
        /// ИИН/БИН поставщика/отправителя
        /// </summary>
        public string SellerTin { get; set; }

        /// <summary>
        /// ИИН/БИН получателя
        /// </summary>
        public string CustomerTin { get; set; }

        /// <summary>
        /// Номер СНТ из учетной системы
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Регистрационный номер СНТ
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Id склада отправителя
        /// </summary>
        public int? SellerStoreId { get; set; }

        /// <summary>
        /// Id склада получателя
        /// </summary>
        public int? CustomerStoreId { get; set; }

        public SntCategory? Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Type == null)
            {
                // ImportType, ExportType, TransferType can be specified only after the Type property
                if (ImportType != null)
                    yield return new ValidationResult($"{nameof(ImportType)} must be null when {nameof(Type)} not specified", new[] { nameof(ImportType) });
                if (ExportType != null)
                    yield return new ValidationResult($"{nameof(ExportType)} must be null when {nameof(Type)} not specified", new[] { nameof(ExportType) });
                if (TransferType != null)
                    yield return new ValidationResult($"{nameof(TransferType)} must be null when {nameof(Type)} not specified", new[] { nameof(TransferType) });
            }
            else
            {
                // ImportType, ExportType and TransferType can be specified only for the corresponging Type
                if (ImportType != null && Type.Value != SntFilterType.PRIMARY_SNT)
                    yield return new ValidationResult($"{nameof(ImportType)} can be specified only for the PRIMARY_SNT", new[] { nameof(ImportType) });
                if (ExportType != null && Type.Value != SntFilterType.EXPORT_SNT)
                    yield return new ValidationResult($"{nameof(ExportType)} can be specified only for the EXPORT_SNT", new[] { nameof(ExportType) });
                if (TransferType != null && Type.Value != SntFilterType.TRANSFER_SNT)
                    yield return new ValidationResult($"{nameof(TransferType)} can be specified only for the TRANSFER_SNT", new[] { nameof(TransferType) });
            }
        }
    }
}
