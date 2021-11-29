using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormFull
{
    public class UFormProductDto
    {
        public string GsvsCode { get; set; }

        public int MeasureUnitId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? ProductId { get; set; }

        public int? BalanceId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Sum { get; set; }

        public string TnvedCode { get; set; }

        public string PinCode { get; set; }
       
        public string ProductNameInImportDoc { get; set; }

        public string ProductNumberInImportDoc { get; set; }

        public UFormCustomsDutyType? DutyTypeCode { get; set; }

        public string ManufactureOrImportCountry { get; set; }

        public string ManufactureOrImportDocNumber { get; set; }

        public string OriginCode { get; set; }
    }
}