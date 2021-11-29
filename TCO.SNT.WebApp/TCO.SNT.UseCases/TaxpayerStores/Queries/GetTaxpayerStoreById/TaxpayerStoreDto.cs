using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetTaxpayerStoreById
{
    public class TaxpayerStoreDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор в ЕСФ
        /// </summary>
        public long ExternalId { get; set; }

        /// <summary>
        /// Наименование склада
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public StoreType Type { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public TaxpayerStoreStatus Status { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Приоритетный склад
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Признак оприходования товаров по ДТ
        /// </summary>
        public bool IsPostingGoods { get; set; }

        /// <summary>
        /// Склад реорганизуемого лица
        /// </summary>
        public bool IsInherited { get; set; }

        /// <summary>
        /// Склад УСД
        /// </summary>
        public bool IsJointStore { get; set; }

        /// <summary>
        /// ИИН ответственного лица
        /// </summary>
        [Required]
        public string ResponsiblePersonIin { get; set; }
    }
}
