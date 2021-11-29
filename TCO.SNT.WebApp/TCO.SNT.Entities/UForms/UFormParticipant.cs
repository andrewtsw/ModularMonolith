using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Options;

namespace TCO.SNT.Entities
{
    public abstract class UFormParticipant
    {
        public const int TinMaxLen = 50;

        public int UFormId { get; set; }

        public UForm UForm { get; set; }

        /// <summary>
        /// Адрес НП
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Дата контракта оператора
        /// </summary>
        public string AgentDocDate { get; set; }

        /// <summary>
        /// Номер контракта оператора
        /// </summary>
        public string AgentDocNum { get; set; }

        /// <summary>
        /// Наименование НП
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Id склада в ЭСФ
        /// </summary>
        public long ExternalStoreId { get; set; }

        public int TaxpayerStoreId { get; private set; }
        public TaxpayerStore TaxpayerStore { get; private set; }

        /// <summary>
        /// Наименование Склада
        /// </summary>
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// ИИН/БИН НП
        /// </summary>
        [Required]
        [MaxLength(TinMaxLen)]
        public string Tin { get; set; }

        public void SetStore(TaxpayerStore store)
        {
            TaxpayerStoreId = store.Id;
            TaxpayerStore = store;
        }

        public void FillStore(TaxpayerStore store)
        {
            SetStore(store);
            StoreName = store.StoreName;
            ExternalStoreId = store.ExternalId;
        }

        public void FillCompanyOptions(CompanyOptions options)
        {
            Address = options.Address;
            Name = options.Name;
            Tin = options.Tin;
        }

        public void ClearAgentDoc()
        {
            AgentDocDate = null;
            AgentDocNum = null;
        }
    }
}
