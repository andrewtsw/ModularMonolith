using TCO.SNT.Entities;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public class SntReportFilter
    {
        public SntReportFilter(SntCategory? category, SntFilterType? type, SntStatus? status)
        {
            Category = category;
            Type = type;
            Status = status;
        }

        public SntCategory? Category { get; }

        public SntFilterType? Type { get; }

        public SntStatus? Status { get; }

    }
}