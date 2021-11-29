using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Products.Queries.GetFavoriteProducts
{
    /// <summary>
    /// ГСВС
    /// </summary>
    public class FavoriteProductDto
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
        /// Составной код ГСВС 
        /// </summary>
        [Required]
        public string CompositeCode { get; set; }
    }
}
