using ClosedXML.Excel;
using System.IO;

namespace TCO.SNT.Infrastructure.Implementation.ReportBuilders
{
    public abstract class ReportBuilderBase
    {
        public Stream GetWorksheetStream(IXLWorkbook workbook)
        {
            Stream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }
    }
}
