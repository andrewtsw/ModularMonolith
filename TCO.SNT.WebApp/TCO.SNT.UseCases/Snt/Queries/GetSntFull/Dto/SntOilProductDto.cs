using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntFull
{
    public class SntOilProductDto : SntProductDtoBase
    {
        /// <summary>
        /// Код ТНВЭД ЕАЭС
        /// </summary>        
        public string TnvedCode { get; set; }

        /// <summary>
        /// Наименование единицы измерения
        /// </summary>      
        public string MeasureUnitName { get; set; }

        /// <summary>
        /// ПИН-код (G6 3)
        /// </summary>
        public string PinCode { get; set; }
    }
}
