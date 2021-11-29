using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalanceReport
{
    public class BalanceListReportResponseDto
    {
        public Stream FileStream { get; set; }

        public string FileName { get; set; }
    }
}
