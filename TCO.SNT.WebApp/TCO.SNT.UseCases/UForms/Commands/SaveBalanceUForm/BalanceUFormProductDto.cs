using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveBalanceUForm
{
    public class BalanceUFormProductDto : UFormProductDtoBase
    {
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int GsvsId { get; set; }

        public int MeasureUnitId { get; set; }

        public UFormCustomsDutyType DutyTypeCode { get; set; }

        [Required]
        public string ManufactureOrImportCountry { get; set; }

        public string ManufactureOrImportDocNumber { get; set; }

        [Range(1, 6)]
        public int OriginCode { get; set; }

        public string ProductNumberInImportDoc { get; set; }

        public string ProductNameInImportDoc { get; set; }

        public string PinCode { get; set; }
    }
}
