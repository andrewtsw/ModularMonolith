using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveManufactureUForm
{
    public class ManufactureUFormDto : UFormDtoBase
    {
        /// <summary>
        /// Товары
        /// </summary>
        [Required]
        [MinLength(1)]
        public ManufactureUFormProductDto[] Products { get; set; }

        public override IEnumerable<UFormProductDtoBase> GetProducts() => Products;

        public override UFormType GetUFormType() => UFormType.MANUFACTURE;
    }
}
