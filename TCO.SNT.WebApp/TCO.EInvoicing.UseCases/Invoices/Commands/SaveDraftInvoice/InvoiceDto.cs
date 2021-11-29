using System;
using System.ComponentModel.DataAnnotations;
using TCO.EInvoicing.Entities;
using TCO.SNT.Common.Validation;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    public class InvoiceDto
    {
        /// <summary>
        /// Идентификатор существующего invoice или null для нового
        /// </summary>
        [Range(1, int.MaxValue)]
        public int? Id { get; set; }

        /// <summary>
        /// Исходящий номер ЭСФ в бухгалтерии отправителя (A 1)
        /// </summary>
        [Required]
        public string Num { get; set; }

        /// <summary>
        /// Дата совершения оборота (A 3)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime TurnoverDate { get; set; }

        /// <summary>
        /// Поставщик (B)
        /// </summary>
        [Required]
        public InvoiceSellerDto Seller { get; set; }

        /// <summary>
        /// Получатель (C)
        /// </summary>
        [Required]
        public InvoiceCustomerDto Customer { get; set; }

        /// <summary>
        /// Реквизиты грузоотправителя (D 25)
        /// </summary>
        [Required]
        public InvoiceConsignorDto Consignor { get; set; }

        /// <summary>
        /// Реквизиты грузополучателя (D 26)
        /// </summary>
        [Required]
        public InvoiceConsigneeDto Consignee { get; set; }

        /// <summary>
        /// Условия поставки (E)
        /// </summary>
        [Required]
        public InvoiceDeliveryTermDto DeliveryTerm { get; set; }

        /// <summary>
        /// Дата документа, подтверждающего поставку товаров (работ, услуг) (F 32.2)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DeliveryDocDate { get; set; }

        /// <summary>
        /// Номер документа, подтверждающего поставку товаров (работ, услуг) (F 32.1)
        /// </summary>
        public string DeliveryDocNum { get; set; }

        #region Products

        /// <summary>
        /// Код валюты (G 33.1)
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Курс валюты (G 33.2)
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Тип НДС ('Без НДС – не РК')
        /// </summary>
        public InvoiceNdsRateType? NdsRateType { get; set; }

        /// <summary>
        /// Товары (работы, услуги) (G)
        /// </summary>
        [Required]
        public InvoiceProductDto[] Products { get; set; }

        #endregion

        /// <summary>
        /// Дополнительные сведения (K 43)
        /// </summary>
        public string AddInf { get; set; }
    }
}
