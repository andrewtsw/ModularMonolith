using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.Finportal.Framework.Domain.Entities
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    public class MeasureUnit : EntityBase
    {
        /// <summary>
        /// Код единицы измерения
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Code { get; set; }

        /// <summary>
        /// Код единицы измерения МКЕИ
        /// </summary>
        [MaxLength(16)]
        public string CodeMkei { get; set; }

        /// <summary>
        /// Код единицы измерения ОКЕИ
        /// </summary>
        [MaxLength(16)]
        public string CodeOkei { get; set; }

        /// <summary>
        /// Код единицы измерения ТИС
        /// </summary>
        [MaxLength(16)]
        public string CodeTis { get; set; }

        /// <summary>
        /// Дата и время последнего обновления
        /// </summary>
        public DateTimeOffset LastUpdateDateUtc { get; set; }

        /// <summary>
        /// Наименование единицы измерения на казахском языке
        /// </summary>
        [Required]
        [MaxLength(400)]
        public string NameKz { get; set; }

        /// <summary>
        /// Наименование единицы измерения на русском языке
        /// </summary>
        [Required]
        [MaxLength(400)]
        public string NameRu { get; set; }
    }
}
