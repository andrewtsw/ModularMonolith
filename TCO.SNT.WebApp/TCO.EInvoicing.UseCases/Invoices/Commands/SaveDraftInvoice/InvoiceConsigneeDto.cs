namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    /// <summary>
    /// Реквизиты грузополучателя (D 26)
    /// </summary>
    public class InvoiceConsigneeDto
    {
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
