using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Snt.Extensions;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.Common.Options;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntListReport
{
    class GetSntListReportQueryHandler : IRequestHandler<GetSntListReportQuery, SntListReportResponseDto>
    {
        private readonly IDbContext _context;
        private readonly ISntReportBuilder _sntReportBuilder;
        private readonly SntReportOptions _reportOptions;
        private readonly CompanyOptions _companyOptions;

        public GetSntListReportQueryHandler(IDbContext context,
             ISntReportBuilder sntReportBuilder,
             IOptions<SntReportOptions> reportOptions,
             IOptions<CompanyOptions> companyOptions)
        {
            _context = context;
            _sntReportBuilder = sntReportBuilder;
            _reportOptions = reportOptions.Value;
            _companyOptions = companyOptions.Value;
        }

        public async Task<SntListReportResponseDto> Handle(GetSntListReportQuery request, CancellationToken cancellationToken)
        {
            var sntList = await _context.Snts
                .AddAllSntIncludes()
                .ApplyFilter(request.Filter, _companyOptions)
                .OrderBy(q => q.Date)
                .ToListAsync(cancellationToken);

            var filterParams = new SntReportFilter(request.Filter.Category, request.Filter.Type, request.Filter.Status);
            var stream = _sntReportBuilder.BuildSntListReport(sntList, filterParams, request.BasePath);

            return new SntListReportResponseDto
            {
                FileName = _reportOptions.FileName,
                FileStream = stream
            };
        }
    }
}
