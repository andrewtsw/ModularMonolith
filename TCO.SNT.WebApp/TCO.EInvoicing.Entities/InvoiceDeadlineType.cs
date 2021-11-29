namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Тип контроля сроков
    /// </summary>
    public enum InvoiceDeadlineType
    {
        /// <summary>
        /// Отклонение ЭСФ
        /// </summary>
        DECLINE,

        /// <summary>
        /// Отклонение отзыва ЭСФ
        /// </summary>
        UNREVOKE,

        /// <summary>
        /// Общий срок реализации по этапу
        /// </summary>
        TotalImplementationStageDeadline,

        /// <summary>
        /// Общий срок оплаты по этапу
        /// </summary>
        TotalPaymentStageDeadline,

        /// <summary>
        /// Общий срок реализации
        /// </summary>
        TotalImplementationDeadline,

        /// <summary>
        /// Общий срок оплаты
        /// </summary>
        TotalPaymentDeadline,

        /// <summary>
        /// Срок реализации по данному ТРУ
        /// </summary>
        ImplementationDeadline,

        /// <summary>
        /// Срок оплаты по данному ТРУ
        /// </summary>
        PaymentDeadline,

        /// <summary>
        /// Дата погашения
        /// </summary>
        PaymentDate,

        /// <summary>
        /// Дата окончания платежей
        /// </summary>
        PaymentEndDate,

        /// <summary>
        /// Дата окончания подтверждения/отклонения
        /// </summary>
        SntConfirmDeadline,

        /// <summary>
        /// Дата окончания отзыва
        /// </summary>
        SntCancelDeadline,

        /// <summary>
        /// Дата формирования основной ЭСФ на основании СНТ
        /// </summary>
        SntOriginalEsfDeadline,

        /// <summary>
        /// Дата формирования дополнительной ЭСФ на основании СНТ
        /// </summary>
        SntAdditionalEsfDeadline
    }
}
