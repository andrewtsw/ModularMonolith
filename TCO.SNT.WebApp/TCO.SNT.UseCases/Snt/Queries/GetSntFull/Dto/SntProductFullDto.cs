using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntFull
{
    public class SntProductFullDto : SntProductDtoBase
    {
        /// <summary>
        /// Код товара (GTIN) (G1 16)
        /// </summary>
        public string GtinCode { get; set; }

        /// <summary>
        /// Код ТНВЭД ЕАЭС
        /// </summary>        
        public string TnvedCode { get; set; }

        /// <summary>
        /// Наименование единицы измерения
        /// </summary>      
        public string MeasureUnitName { get; set; }
    }
}
