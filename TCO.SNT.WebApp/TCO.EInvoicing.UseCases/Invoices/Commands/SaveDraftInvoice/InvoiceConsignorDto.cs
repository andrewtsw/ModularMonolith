namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    /// <summary>
    /// Реквизиты грузоотправителя (D 25)
    /// </summary>
    public class InvoiceConsignorDto
    {
        /// <summary>
        /// ИИН/БИН (D 25.1)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// Наименование (D 25.2)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес (D 25.3)
        /// </summary>
        public string Address { get; set; }
    }
}
