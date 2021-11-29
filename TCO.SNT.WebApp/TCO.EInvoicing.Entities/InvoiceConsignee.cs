namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Реквизиты грузополучателя (D 26)
    /// </summary>
    public class InvoiceConsignee
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// ИИН/БИН (D 26.1)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// Наименование (D 26.2)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес (D 26.3)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Код страны (D 26.4)
        /// </summary>
        public string CountryCode { get; set; }
    }
}
