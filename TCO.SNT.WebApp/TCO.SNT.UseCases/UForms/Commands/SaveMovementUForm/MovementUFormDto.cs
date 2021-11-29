using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveMovementUForm
{
    public class MovementUFormDto : UFormDtoBase
    {
        public int RecipientTaxpayerStoreId { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        [Required]
        [MinLength(1)]
        public MovementUFormProductDto[] Products { get; set; }

        public override IEnumerable<UFormProductDtoBase> GetProducts() => Products;

        public override UFormType GetUFormType() => UFormType.MOVEMENT;
    }
}
