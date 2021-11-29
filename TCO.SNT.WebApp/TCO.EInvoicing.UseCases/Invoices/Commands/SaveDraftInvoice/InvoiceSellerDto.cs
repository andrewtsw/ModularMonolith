using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    /// <summary>
    /// Поставщик (B)
    /// </summary>
    public class InvoiceSellerDto
    {
        /// <summary>
        /// Cтруктурное подразделение юридического лица-нерезидента (B 9.3)
        /// </summary>
        public bool? IsBranchNonResident { get; set; }

        /// <summary>
        /// Категория поставщика (B 10)
        /// </summary>
        public InvoiceSellerType[] Statuses { get; set; }

        /// <summary>
        /// Дополнительные сведения (B 11)
        /// </summary>
        public string Trailer { get; set; }

        /// <summary>
        /// КБе (B1 12)
        /// </summary>
        public string Kbe { get; set; }

        /// <summary>
        /// Расчетный счет (B1 13)
        /// </summary>
        public string Iik { get; set; }

        /// <summary>
        /// БИК (B1 14)
        /// </summary>
        public string Bik { get; set; }

        /// <summary>
        /// Наименование банка (B1 15)
        /// </summary>
        public string Bank { get; set; }
    }
}
