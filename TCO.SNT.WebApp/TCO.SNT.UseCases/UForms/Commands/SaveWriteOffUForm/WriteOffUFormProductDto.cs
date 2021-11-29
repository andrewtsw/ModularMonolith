using System.ComponentModel.DataAnnotations;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveWriteOffUForm
{
    public class WriteOffUFormProductDto : UFormProductDtoBase
    {
        [Range(1, int.MaxValue)]
        public int BalanceId { get; set; }
    }
}
