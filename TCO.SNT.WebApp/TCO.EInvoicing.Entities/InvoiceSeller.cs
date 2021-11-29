using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Common.Options;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Реквизиты поставщика (B)
    /// </summary>
    public class InvoiceSeller : EntityBase
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// ИИН/БИН (B 6)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// БИН филиала, выписавшего ЭСФ за голову
        /// </summary>
        public string BranchTin { get; set; }

        /// <summary>
        /// БИН реорганизованного лица (B 6.1)
        /// </summary>
        public string ReorganizedTin { get; set; }

        /// <summary>
        /// Наименование поставщика (B 7)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Доля участия (B 7.1)
        /// </summary>
        public decimal? ShareParticipation { get; set; }

        /// <summary>
        /// Адрес (B 8)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Серия cвидетельства НДС (B 9.1)
        /// </summary>
        public string CertificateSeries { get; set; }

        /// <summary>
        /// Номер cвидетельства НДС (B 9.2)
        /// </summary>
        public string CertificateNum { get; set; }

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

        #region Ndsca

        /// <summary>
        /// Наименование банка контрольного счета (B2 15.1)
        /// </summary>
        public string NdscaBank { get; set; }

        /// <summary>
        /// БИК контрольного счета (B2 14.1)
        /// </summary>
        public string NdscaBik { get; set; }

        /// <summary>
        /// ИИК контрольного счета (B2 13.1)
        /// </summary>
        public string NdscaIik { get; set; }

        /// <summary>
        /// КБе контрольного счета (B2 12.1)
        /// </summary>
        public string NdscaKbe { get; set; }

        #endregion

        public void FillCompanyOptions(CompanyOptions options)
        {
            Tin = options.Tin;
            Name = options.Name;
            Address = options.Address;
            CertificateNum = options.CertificateNum;
            CertificateSeries = options.CertificateSeries;
        }
    }
}
