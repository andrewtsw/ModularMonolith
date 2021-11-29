using System;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Служит для связки исправленного/дополнительного ЭСФ с основным
    /// </summary>
    public class RelatedInvoice
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Дата выписки ЭСФ (A 4.1, A 5.1)
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Исходящий номер ЭСФ в бухгалтерии отправителя (A 4.2, A 5.2)
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// Регистрационный номер ЭСФ на которую ссылается данная ЭСФ
        /// </summary>
        public string RegistrationNumber { get; set; }
    }
}
