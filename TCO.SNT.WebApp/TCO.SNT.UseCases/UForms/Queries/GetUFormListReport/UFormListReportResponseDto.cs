using System.IO;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormListReport
{
    public class UFormListReportResponseDto
    {
        public Stream FileStream { get; set; }

        public string FileName { get; set; }
    }
}
