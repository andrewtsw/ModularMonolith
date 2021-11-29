using ClosedXML.Report;
using System.Collections.Generic;
using System.IO;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.Infrastructure.Implementation.ReportBuilders
{
    public class UFormReportBuilder : ReportBuilderBase, IUFormReportBuilder
    {
        private readonly IDateTime _dateTime;

        const string reportFilePath = @"ReportBuilders\Templates\UForm-Report.xlsx";

        public UFormReportBuilder(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public Stream BuildUformListReport(IReadOnlyList<UFormReport> UformList, string basePath)
        {
            var templatePath = Path.Combine(basePath, reportFilePath);
            var template = new XLTemplate(templatePath);

            var uFormReport = new
            {
                Uforms = UformList,
                GeneratedDateTime = _dateTime.UtcNow.ToStringCommonDateFormat()
            };

            template.AddVariable(uFormReport);
            template.Generate();

            return GetWorksheetStream(template.Workbook);
        }

    }
}