using System.ComponentModel.DataAnnotations;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveManufactureUForm
{
    public class ManufactureUFormProductDto : UFormProductDtoBase
    {
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int MeasureUnitId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}