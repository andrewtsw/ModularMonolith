using System;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Условия поставки (E)
    /// </summary>
    public class InvoiceDeliveryTerm
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Дата договора(контракт) на поставку товаров (работ, услуг) (E 27.4)
        /// </summary>
        public DateTime? ContractDate { get; set; }

        /// <summary>
        /// Номер договора(контракт) на поставку товаров (работ, услуг) (E 27.3)
        /// </summary>
        public string ContractNum { get; set; }

        /// <summary>
        /// Условия поставки (E 31.1)
        /// </summary>
        public string DeliveryConditionCode { get; set; }

        /// <summary>
        /// Пункт назначения поставляемых товаров (работ, услуг) (E 31)
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Договор/без договора (E 27.1 - true, E27.2 - false)
        /// </summary>
        public bool HasContract { get; set; }

        /// <summary>
        /// Условия оплаты по договору (E 28)
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Способ отправления (E 29)
        /// </summary>
        public string TransportTypeCode { get; set; }

        /// <summary>
        /// Номер доверенности на поставку товаров (работ, услуг) (E 30.1)
        /// </summary>
        public string Warrant { get; set; }

        /// <summary>
        /// Дата доверенности на поставку товаров (работ, услуг) (E 30.2)
        /// </summary>
        public DateTime? WarrantDate { get; set; }
    }
}
