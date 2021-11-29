using System;
using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Склад налогоплательщика
    /// </summary>
    public class TaxpayerStore : EntityBase
    {
        /// <summary>
        /// Id во внешней системе
        /// </summary>
        public long ExternalId { get; set; }

        /// <summary>
        /// Адрес склада
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор лицензии на алкогольную продукцию
        /// </summary>
        public long? AlcoholLicenseId { get; set; }

        /// <summary>
        /// Скан подтверждающих документов о складе
        /// </summary>
        public long? ExternalDocumentId { get; set; }

        /// <summary>
        /// Склад для лизинга
        /// Если флаг выставлен - указываются параметры LesseeTin, LesseeContractNumber, LesseeContractDate
        /// Если сброшен - эти 3 параметра очишаются
        /// </summary>
        public bool? IsCooperativeStore { get; set; }

        /// <summary>
        /// Приоритетный склад
        /// В системе обязательно нужен как минимум один приоритетный склад.
        /// И только один склад может быть приоритетным.
        /// Приоритетный склад не может быть деактивирован.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Склад реорганизуемого лица
        /// </summary>
        public bool IsInherited { get; set; }

        /// <summary>
        /// Склад УСД.
        /// Если поле выставлено - обязательно указать PermittedTinList
        /// Если флаг сброшен - тогда список PermittedTinList очишается
        /// </summary>
        public bool IsJointStore { get; set; }

        /// <summary>
        /// Признак оприходования товаров по ДТ
        /// </summary>
        public bool IsPostingGoods { get; set; }

        /// <summary>
        /// Переработка давальческого сырья
        /// </summary>
        public bool? IsRawMaterials { get; set; }

        /// <summary>
        /// Признак публичного склада
        /// </summary>
        public bool? IsPublicStore { get; set; }

        /// <summary>
        /// Дата договора лизингополучателя
        /// </summary>
        public DateTimeOffset? LesseeContractDateUtc { get; set; }

        /// <summary>
        /// Номер договора лизингополучателя
        /// </summary>
        public string LesseeContractNumber { get; set; }

        /// <summary>
        /// БИН/ИИН Лизингополучателя
        /// </summary>
        public string LesseeTin { get; set; }

        /// <summary>
        /// Идентификатор справочника ОВД по отдельным видам нефтепродуктов
        /// </summary>
        public long? OilOvdId { get; set; }

        /// <summary>
        /// Id родительского склада во внешней сиситеме
        /// </summary>
        public long? ExternalParentId { get; set; }

        /// <summary>
        /// Список разрешенных БИН-ов УСД
        /// </summary>
        public string[] PermittedTinList { get; set; }

        /// <summary>
        /// ИИН ответственного лица
        /// </summary>
        [Required]
        public string ResponsiblePersonIin { get; set; }

        /// <summary>
        /// Статус Склада НП в системе ЭСФ
        /// </summary>
        public TaxpayerStoreStatus Status { get; set; }

        /// <summary>
        /// Наименование склада
        /// </summary>
        [Required]
        public string StoreName { get; set; }

        /// <summary>
        /// Тип склада
        /// </summary>
        public StoreType StoreTypeCode { get; set; }

        /// <summary>
        /// БИН
        /// </summary>
        [Required]
        public string Tin { get; set; }

        /// <summary>
        /// Идентификатор справочника ОВД по табачным изделиям
        /// </summary>
        public long? TobaccoOvdId { get; set; }
    }
}
