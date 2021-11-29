using System;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Договор (контракт) на поставку товара (F)
    /// </summary>
    public class SntContract
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// Договор (контракт) или приложение к договору  (F 44.a, F 44.b)
        /// </summary>
        public bool IsContract { get; set; }

        /// <summary>
        /// Номер (F 44.1)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата (F 44.2)
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Условия оплаты по договору (F 45)
        /// </summary>
        public string TermOfContractPayment { get; set; }

        /// <summary>
        /// Условия поставки (ИНКОТЕРМС) (F 45.1)
        /// </summary>
        public string DeliveryCondition { get; set; }
    }
}
