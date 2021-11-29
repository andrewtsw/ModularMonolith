namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Реквизиты государственного учреждения (C1)
    /// </summary>
    public class InvoicePublicOffice
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// БИК. Неизменяемое поле (C1 24)
        /// </summary>
        public string Bik { get; set; }

        /// <summary>
        /// ИИК (C1 21)
        /// </summary>
        public string Iik { get; set; }

        /// <summary>
        /// Назначение платежа (C1 23)
        /// </summary>
        public string PayPurpose { get; set; }

        /// <summary>
        /// Код товаров (работ, услуг) (C1 22)
        /// </summary>
        public string ProductCode { get; set; }
    }
}
