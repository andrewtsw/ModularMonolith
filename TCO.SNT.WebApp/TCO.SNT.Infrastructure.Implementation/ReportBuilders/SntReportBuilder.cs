using AutoMapper;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using ClosedXML.Report;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.Resources;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Entities;

namespace TCO.SNT.Infrastructure.Implementation.ReportBuilders
{
    public class SntReportBuilder : ReportBuilderBase, ISntReportBuilder
    {
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        const string reportFilePath = @"ReportBuilders\Templates\Snt-Report.xlsx";
        const string allTypesText = "Все";

        public SntReportBuilder(IMapper mapper, IDateTime dateTime)
        {
            _mapper = mapper;
            _dateTime = dateTime;
        }

        private class SntReportData
        {
            public string GeneratedDateTime { get; set; }

            public string SntDateFrom { get; set; }

            public string SntDateTo { get; set; }

            public string SntType { get; set; }

            public string SntCategory { get; set; }

            public string SntStatus { get; set; }

            public IEnumerable<SntReportRow> SntList { get; set; }

        }

        public Stream BuildSntListReport(IEnumerable<Snt> sntList, SntReportFilter filterParams, string basePath)
        {
            var templatePath = Path.Combine(basePath, reportFilePath);
            var template = new XLTemplate(templatePath);

            var sntReport = GetSntReportDataFromSntList(sntList, filterParams);

            template.AddVariable(sntReport);
            template.Generate();

            return GetWorksheetStream(template.Workbook);
        }


        public string BuildSntNotification(IReadOnlyList<Snt> snts)
        {
            var result = new StringBuilder();
            result.Append(SntNotificationResource.NotificatuionTableTemplateStart);

            var idx = 1;
            foreach (var snt in snts)
            {
                var sntDeadline = snt.GetDeadline().Value;
                var deadlineTemplate = snt.IsExceedDeadline(_dateTime.UtcNow) ?
                                    SntNotificationResource.NotificationDeadlineExceedTemplate :
                                    SntNotificationResource.NotificationDeadlineNotExceedTemplate;
                var deadlineCell = string.Format(deadlineTemplate, sntDeadline.ToStringCommonDateFormat());

                result.Append(string.Format(SntNotificationResource.NotificationRowTemplate,
                    idx,
                    snt.SntInfo.RegistrationNumber,
                    snt.Contract.Number,
                    snt.Date.Value.ToStringCommonDateFormat(),
                    deadlineCell,
                    SntStatusResource.ResourceManager.GetString(snt.SntInfo.Status.ToString())
                    ));

                idx++;
            }

            result.Append(SntNotificationResource.NotificatuionTableTemplateEnd);
            return result.ToString();
        }

        private SntReportData GetSntReportDataFromSntList(IEnumerable<Snt> sntList, SntReportFilter filterParams)
        {
            var reportRows = new List<SntReportRow>();
            foreach (var snt in sntList)
            {
                var products = _mapper.Map<IReadOnlyList<SntReportRow>>(snt.Products);
                var oilProducts = _mapper.Map<IReadOnlyList<SntReportRow>>(snt.OilProducts);
                var allproducts = products.Concat(oilProducts);

                var sntReportRows = allproducts.Select(q => _mapper.Map(snt, q));

                reportRows.AddRange(sntReportRows);
            }

            var result = new SntReportData
            {
                SntCategory = filterParams.Category.HasValue ? SntCategoryResource.ResourceManager.GetString(filterParams.Category.ToString()) : allTypesText,
                SntType = filterParams.Type.HasValue ? SntTypeResource.ResourceManager.GetString(filterParams.Type.ToString()) : allTypesText,
                SntStatus = filterParams.Status.HasValue ? SntStatusResource.ResourceManager.GetString(filterParams.Status.ToString()) : allTypesText,
                GeneratedDateTime = _dateTime.UtcNow.ToStringCommonDateFormat(),
                SntDateFrom = sntList
                                .Where(q => q.Date.HasValue)
                                .Min(q => q.Date).Value
                                .ToStringCommonDateFormat(),
                SntDateTo = sntList
                                .Max(q => q.Date).Value
                                .ToStringCommonDateFormat(),
                SntList = reportRows
            };

            return result;
        }
    }
}
