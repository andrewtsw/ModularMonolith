using System;
using TCO.SNT.Common.Validation;

namespace TCO.SNT.UseCases.Snt.Shared
{
    public class SntContractDto
    {
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
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
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
