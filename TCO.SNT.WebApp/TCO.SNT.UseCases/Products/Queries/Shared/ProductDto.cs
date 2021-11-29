using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Products.Queries.Shared
{
    /// <summary>
    /// ГСВС
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код КПВЭД/ТНВЭД/ГТИН
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Тип ГСВС
        /// </summary>
        public GsvsType GsvsTypeCode { get; set; }

        /// <summary>
        /// Наименование ГСВС (КПВЭД/ТНВЭД/GTIN в зависимости от типа) на русском языке
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Id для построения дерева
        /// </summary>
        public long FixedId { get; set; }

        /// <summary>
        /// Признак использования в ВС
        /// </summary>
        public bool? IsUseInVstore { get; set; }

        /// <summary>
        /// Признак уникальности товара
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Признак товара изъятия
        /// </summary>
        public bool? IsWithdrawal { get; set; }

        /// <summary>
        /// Социально значимый продукт
        /// </summary>
        public bool IsSociallySignificant { get; set; }

        /// <summary>
        /// Признак товара двойного назначения
        /// </summary>
        public bool IsTwofoldPurpose { get; set; }

        /// <summary>
        /// Признак подакцизного товара
        /// </summary>
        public bool IsExcisable { get; set; }
    }
}
