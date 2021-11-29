using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Commands.SaveDraft
{
    /// <summary>
    /// Черновик СНТ
    /// </summary>
    public class SntDraftDto : SntBaseDto
    {
        /// <summary>
        /// Товары
        /// </summary>
        public SntDraftProductDto[] Products { get; set; }

        /// <summary>
        /// Нефтепродукты
        /// </summary>
        public SntDraftOilProductDto[] OilProducts { get; set; }
    }
}
