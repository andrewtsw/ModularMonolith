using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Реквищиты получателя (C)
    /// </summary>
    public class InvoiceCustomer : EntityBase
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// ИИН/БИН. Может отсутствовать если установлен статус CustomerType.NONRESIDENT (C 16)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// БИН филиала, выписавшего ЭСФ за голову
        /// </summary>
        public string BranchTin { get; set; }

        /// <summary>
        /// БИН реорганизованного лица (B 16.1)
        /// </summary>
        public string ReorganizedTin { get; set; }

        /// <summary>
        /// Наименование получателя (C 17)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Доля участия (С 17.1)
        /// </summary>
        public decimal? ShareParticipation { get; set; }

        /// <summary>
        /// Адрес (C 18)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Код страны получателя. Обязательно заполняется если установлен статус CustomerType.NONRESIDENT и SellerType.EXPORTER (C 18.1)
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Дополнительные сведения (C 19)
        /// </summary>
        public string Trailer { get; set; }

        /// <summary>
        /// Категория получателя (С 20)
        /// </summary>
        public InvoiceCustomerType[] Statuses { get; set; }
    }
}
