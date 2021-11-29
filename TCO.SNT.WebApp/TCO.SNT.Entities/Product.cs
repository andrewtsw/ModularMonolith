using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Common.Extensions;

namespace TCO.SNT.Entities
{
    public class Product : EntityBase
    {
        public const long RootParentId = 0L;

        /// <summary>
        /// Код КПВЭД/ТНВЭД/ГТИН
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Краткое описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время окончания действия записи
        /// </summary>
        public DateTimeOffset? EndDateUtc { get; set; }

        /// <summary>
        /// Сквозной код, который будет постоянным при изменении
        /// </summary>
        public long FixedId { get; set; }

        /// <summary>
        /// Ссылка на сквозной код родителя
        /// </summary>
        public long FixedParentId { get; set; }

        /// <summary>
        /// Код ГСВС в формате КПВЭД[-ТНВЭД][/GTIN]
        /// </summary>
        public string GsvsCode { get; set; }

        /// <summary>
        /// Тип ГСВС
        /// </summary>
        public GsvsType GsvsTypeCode { get; set; }

        /// <summary>
        /// External Id
        /// </summary>
        public long ExternalId { get; set; }

        /// <summary>
        /// Признак, что данный код можно выбрать/указать в ЭСФ
        /// </summary>
        public bool? IsCanSelect { get; set; }

        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Признак подакцизного товара
        /// </summary>
        public bool IsExcisable { get; set; }

        /// <summary>
        /// Признак товара двойного назначения
        /// </summary>
        public bool IsTwofoldPurpose { get; set; }

        /// <summary>
        /// Признак уникальности товара
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Признак использования в ВС
        /// </summary>
        public bool? IsUseInVstore { get; set; }

        /// <summary>
        /// Признак товара изъятия
        /// </summary>
        public bool? IsWithdrawal { get; set; }

        /// <summary>
        /// Социально значимый продукт
        /// </summary>
        public bool IsSociallySignificant { get; set; }

        /// <summary>
        /// Тип Классификатора КПВЭД
        /// </summary>
        public KpvedType? KpvedTypeCode { get; set; }

        /// <summary>
        /// Дата и время последнего изменения
        /// </summary>
        public DateTimeOffset LastUpdateDateUtc { get; set; }

        /// <summary>
        /// Наименование ГСВС(КПВЭД/ТНВЭД/GTIN в зависимости от типа) на английском языке
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// Наименование ГСВС(КПВЭД/ТНВЭД/GTIN в зависимости от типа) на казахском языке
        /// </summary>
        public string NameKz { get; set; }

        /// <summary>
        /// Наименование ГСВС(КПВЭД/ТНВЭД/GTIN в зависимости от типа) на русском языке
        /// </summary>
        [Required]
        public string NameRu { get; set; }

        /// <summary>
        /// Дата и время начала действия записи
        /// </summary>
        public DateTimeOffset StartDateUtc { get; set; }

        public bool IsAvailableForSnt()
        {
            return GsvsTypeCode.In(GsvsType.TNVED, GsvsType.GTIN);
        }

        public static string GetGsvsCodeFromFullCode(string fullGsvsCode)
        {
            // Correct GSVS code contains at least one '-' or '/' symbol
            return fullGsvsCode.Split('-', '/').Last();
        }

        public static string ComposeFullGsvsCode(GsvsType type, string code1, string code2, string code3)
        {
            return type switch
            {
                GsvsType.GTIN => $"{code3}-{code2}/{code1}",
                GsvsType.TNVED => $"{code2}-{code1}",
                GsvsType.KPVED => code1,
                _ => throw new InvalidOperationException($"Unknown GsvsType: {type}"),
            };
        }
    }
}
