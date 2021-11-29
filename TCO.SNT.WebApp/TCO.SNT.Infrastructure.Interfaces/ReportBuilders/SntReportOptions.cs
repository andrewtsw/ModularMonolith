using System;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public class SntReportOptions
    {
        public Guid AdGroupId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsBodyHtml { get; set; }

        public string FileName { get; set; }

        public string AzureFunctionBasePath { get; set; }
    }
}
