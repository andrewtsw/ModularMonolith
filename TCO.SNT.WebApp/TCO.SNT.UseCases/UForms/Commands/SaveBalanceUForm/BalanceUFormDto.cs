using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveBalanceUForm
{
    public class BalanceUFormDto : UFormDtoBase
    {
        /// <summary>
        /// Товары
        /// </summary>
        [Required]
        [MinLength(1)]
        public BalanceUFormProductDto[] Products { get; set; }

        public override IEnumerable<UFormProductDtoBase> GetProducts() => Products;

        public override UFormType GetUFormType() => UFormType.BALANCE;
    }
}
