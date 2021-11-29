using System.Collections.Generic;
using System.IO;
using TCO.SNT.Entities;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public interface ISntReportBuilder
    {
        public Stream BuildSntListReport(IEnumerable<Snt> sntList, SntReportFilter filterParams, string basePath);

        public string BuildSntNotification(IReadOnlyList<Snt> snts);
    }
}