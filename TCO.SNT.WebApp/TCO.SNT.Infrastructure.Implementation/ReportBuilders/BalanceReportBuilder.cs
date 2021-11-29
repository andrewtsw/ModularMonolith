using ClosedXML.Report;
using System.Collections.Generic;
using System.IO;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Entities;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.Infrastructure.Interfaces.ReportBuilders.BalanceReport;

namespace TCO.SNT.Infrastructure.Implementation.ReportBuilders
{
    public class BalanceReportBuilder : ReportBuilderBase, IBalanceReportBuilder
    {

        private readonly IDateTime _dateTime;

        const string reportFilePath = @"ReportBuilders\Templates\Balance-Report.xlsx";

        public BalanceReportBuilder(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public Stream BuildBalanceListReport(IReadOnlyList<Balance> balances, string basePath)
        {
            var templatePath = Path.Combine(basePath, reportFilePath);
            var template = new XLTemplate(templatePath);

            var balanceReport = new
            {
                Balances = balances,
                GeneratedDateTime = _dateTime.UtcNow.ToStringCommonDateFormat()
            };

            template.AddVariable(balanceReport);
            template.Generate();

            return GetWorksheetStream(template.Workbook);
        }
    }
}
