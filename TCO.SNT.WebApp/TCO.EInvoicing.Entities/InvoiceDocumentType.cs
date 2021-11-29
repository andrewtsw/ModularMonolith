namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Тип документа
    /// </summary>
    public enum InvoiceDocumentType
    {
        /// <summary>
        /// Счет-фактура
        /// </summary>
        INVOICE,

        /// <summary>
        /// Акт выполненных работ
        /// </summary>
        AWP,

        /// <summary>
        /// Электронный договор
        /// </summary>
        ECONTRACT,

        /// <summary>
        /// Черновик Счет-фактуры
        /// </summary>
        INVOICE_DRAFT,

        /// <summary>
        /// Акт выполненных работ ЭГЗ
        /// </summary>
        EGP_AWP,

        /// <summary>
        /// Договор ЭГЗ
        /// </summary>
        EGP_CONTRACT,

        /// <summary>
        /// Сопроводительная накладная на товары
        /// </summary>
        SNT,

        /// <summary>
        /// Разрешительный документ
        /// </summary>
        PERMISSIVE_DOCUMENT,

        /// <summary>
        /// Контрольный счет
        /// </summary>
        KS_ACCOUNT,

        /// <summary>
        /// Платежное поручение
        /// </summary>
        KS_STATEMENT,

        /// <summary>
        /// ДТ
        /// </summary>
        DOCUMENT_GTD,

        /// <summary>
        /// ФНО-328
        /// </summary>
        DOCUMENT_FNO
    }
}