using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces.ReportBuilders.BalanceReport;
using TCO.SNT.UseCases.Balances.Extentions;


namespace TCO.SNT.UseCases.Balances.Queries.GetBalanceReport
{
    internal class GetBalanceReportQueryHandler : IRequestHandler<GetBalanceReportQuery, BalanceListReportResponseDto>
    {
        private readonly IDbContext _context;
        private readonly IBalanceReportBuilder _balanceReportBuilder;
        private readonly BalanceReportOptions _reportOptions;

        public GetBalanceReportQueryHandler(
            IDbContext context,
            IBalanceReportBuilder balanceReportBuilder,
            IOptions<BalanceReportOptions> reportOptions
            )
        {
            _context = context;
            _balanceReportBuilder = balanceReportBuilder;
            _reportOptions = reportOptions.Value;
        }

        public async Task<BalanceListReportResponseDto> Handle(GetBalanceReportQuery request, CancellationToken cancellationToken)
        {
            var balances = await _context.Balances
                .Include(o => o.MeasureUnit)
                .Include(o => o.TaxpayerStore)
                .ApplyFilter(request.Dto.Filter)
                .Where(x => x.IsActive)
                .ApplySorting(request.Dto.Sorting)
                .ToListAsync(cancellationToken);

            var stream = _balanceReportBuilder.BuildBalanceListReport(balances, request.BasePath);

            return new BalanceListReportResponseDto()
            {
                FileStream = stream,
                FileName = _reportOptions.ReportFileName
            };
        }
    }
}
