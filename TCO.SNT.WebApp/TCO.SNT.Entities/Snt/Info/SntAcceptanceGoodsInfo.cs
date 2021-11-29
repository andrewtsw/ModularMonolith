using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Сведения о приемке товара (M)
    /// </summary>
    public class SntAcceptanceGoodsInfo
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// Прием/отклонение товара произвел от имени: (M 84)
        /// </summary>
        [Required]
        public string AcceptanceOrRejectionProducer { get; set; }

        /// <summary>
        /// Дата приема/отклонения товара (M 85)
        /// </summary>
        public DateTime AcceptanceOrRejectionDate { get; set; }

        /// <summary>
        /// ЭЦП юридического лица (структурного подразделения юридического лица) или индивидуального предпринимателя либо лица. занимающегося частной практикой (M 85.1)
        /// </summary>
        public string CompanySignature { get; set; }

        /// <summary>
        /// ЭЦП лица, уполномоченного подтверждать /отклонять сопроводительную накладную на товары (M 85.2)
        /// </summary>
        public string OperatorSignature { get; set; }

        /// <summary>
        /// Ф.И.О. (при его наличии) лица, подтвердившего/отклонившего сопроводительную накладную на товары (M 86)
        /// </summary>
        [Required]
        public string AcceptanceOrRejectionName { get; set; }

        /// <summary>
        /// Номер доверенности, по которой осуществляется приемка товара (86.2)
        /// </summary>
        public string PowerOfAttorneyNumber { get; set; }

        /// <summary>
        /// Дата доверенности, по которой осуществляется приемка товара (86.3)
        /// </summary>
        public string PowerOfAttorneyDate { get; set; }

    }
}
