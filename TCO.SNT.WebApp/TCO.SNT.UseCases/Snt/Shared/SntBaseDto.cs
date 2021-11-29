using System;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Validation;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Snt.Shared
{
    /// <summary>
    /// СНТ
    /// </summary>
    public abstract class SntBaseDto
    {
        /// <summary>
        /// Идентификатор существующей СНТ или null для новой СНТ
        /// </summary>
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }

        #region General section

        /// <summary>
        /// Регистрационный номер СНТ учетной системы (A 1)
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Регистрационный номер связанной СНТ
        /// </summary>
        public string RelatedRegistrationNumber { get; set; }

        /// <summary>
        /// Дата оформления СНТ на бумажном носителе (A 2.1)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DatePaper { get; set; }

        /// <summary>
        /// Причина выписки на бумажном носителе (A 2.1.1)
        /// </summary>
        public SntPaperReasonType? ReasonPaper { get; set; }

        /// <summary>
        /// Дата отгрузки товара (A 3)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? ShippingDate { get; set; }

        /// <summary>
        /// Регистрационный номер Акта/Уведомления по цифровой маркировке (A 4.2)
        /// </summary>
        public string DigitalMarkingNotificationNumber { get; set; }

        /// <summary>
        /// Дата Акта/Уведомления по цифровой маркировке (A 4.2.1)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DigitalMarkingNotificationDate { get; set; }

        #region SntImport - Ввоз товаров на территорию РК (A 7)

        /// <summary>
        /// Ввоз товаров на территорию РК (A 7)
        /// </summary>
        public SntImportType? ImportType { get; set; }

        /// <summary>
        /// Импорт: Код (идентификатор) территории СЭЗ (A 7.5.1)
        /// </summary>
        public long? ExternalImportSezCode { get; set; }

        #endregion

        #region SntExport - Вывоз товаров с территории РК (A 8)

        /// <summary>
        /// Вывоз товаров с территории РК (A 8)
        /// </summary>
        public SntExportType? ExportType { get; set; }

        /// <summary>
        /// Экспорт: Код (идентификатор) территории СЭЗ (A 8.5.1)
        /// </summary>
        public long? ExternalExportSezCode { get; set; }

        #endregion

        /// <summary>
        /// Перемещение товара (A 9)
        /// </summary>
        public SntTransferType? TransferType { get; set; }

        #endregion

        /// <summary>
        /// Реквизиты поставщика (B)
        /// </summary>
        [Required]
        public SntSellerDto Seller { get; set; }

        /// <summary>
        /// Реквизиты получателя (C)
        /// </summary>
        [Required]
        public SntCustomerDto Customer { get; set; }

        /// <summary>
        /// Грузополучатель (D)
        /// </summary>
        [Required]
        public SntConsignmentParticipantDto Consignee { get; set; }

        /// <summary>
        /// Грузоотправитель (D)
        /// </summary>
        [Required]
        public SntConsignmentParticipantDto Consignor { get; set; }

        /// <summary>
        /// Сведения по перевозке (E)
        /// </summary>
        public SntShippingInfoDto ShippingInfo { get; set; }

        /// <summary>
        /// Договор (контракт) на поставку товара (F)
        /// </summary>
        [Required]
        public SntContractDto Contract { get; set; }

        /// <summary>
        /// Данные о грузе, перевозимом на автомобильном транспорте (K)
        /// </summary>
        public SntCarCargoInfoDto CarCargoInfo { get; set; }

        /// <summary>
        /// Код валюты (50)
        /// </summary>
        [Required]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Курс валюты (51)
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Доп. данные по нефтепродуктам
        /// </summary>
        public SntOilSetDto OilSet { get; set; }
    }
}
