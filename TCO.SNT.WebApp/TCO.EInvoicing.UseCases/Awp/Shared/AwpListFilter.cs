using System;
using TCO.SNT.Common.Validation;

namespace TCO.EInvoicing.UseCases.Awp.Shared
{
    public class AwpListFilter
    {
        /// <summary>
        /// Дата СНТ "с" (yyyy-MM-dd format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата СНТ "по" (yyyy-MM-dd format)
        /// </summary>
        [DateTimeKind(DateTimeKind.Unspecified)]
        [DateOnly]
        public DateTime? DateTo { get; set; }                    

        /// <summary>
        /// Регистрационный номер АВР
        /// </summary>
        public string RegistrationNumber { get; set; }
       
    }
}
