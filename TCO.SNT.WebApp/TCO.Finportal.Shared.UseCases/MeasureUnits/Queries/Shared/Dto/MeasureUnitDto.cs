using System.ComponentModel.DataAnnotations;

namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.Shared.Dto
{
    public class MeasureUnitDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Code { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [MaxLength(400)]
        public string Name { get; set; }
    }
}
