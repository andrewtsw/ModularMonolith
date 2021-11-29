using System.Collections.Generic;
using System.IO;
using TCO.SNT.Entities;

namespace TCO.SNT.Infrastructure.Interfaces.ReportBuilders.BalanceReport
{
    public interface IBalanceReportBuilder
    {
        public Stream BuildBalanceListReport(IReadOnlyList<Balance> balances, string basePath);
    }
}
