using TCO.Finportal.Framework.UseCases;
using TCO.SNT.UseCases.UForms.Shared;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormListReport
{
    public class UFormListReportRequestDto
    {
        public UFormFilter Filter { get; set; }

        public SortingModel Sorting { get; set; }

    }
}
