using System.Collections.Generic;
using System.IO;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public interface IUFormReportBuilder
    {
        public Stream BuildUformListReport(IReadOnlyList<UFormReport> UformList, string basePath);
    }
}