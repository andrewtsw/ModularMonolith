using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.UForms.Extentions;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormListReport
{
    internal class GetUFormListReportQueryHandler : IRequestHandler<GetUFormListReportQuery, UFormListReportResponseDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUFormReportBuilder _uformReportBuilder;
        private readonly ErrorHelper _errorHelper;
        private readonly UFormReportOptions _reportOptions;

        public GetUFormListReportQueryHandler(IDbContext context, IMapper mapper, IUFormReportBuilder uformReportBuilder, ErrorHelper errorHelper, IOptions<UFormReportOptions> reportOptions)
        {
            _context = context;
            _mapper = mapper;
            _uformReportBuilder = uformReportBuilder;
            _errorHelper = errorHelper;
            _reportOptions = reportOptions.Value;
        }

        public async Task<UFormListReportResponseDto> Handle(GetUFormListReportQuery request, CancellationToken cancellationToken)
        {
            var query = _context.UForms
                .ApplyFilter(request.Dto.Filter)
                .ApplySorting(request.Dto.Sorting);

            var forms = await query
                .ProjectTo<UFormReport>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            await _errorHelper.FillErrorDescriptionAsync(forms, cancellationToken);

            var stream = _uformReportBuilder.BuildUformListReport(forms, request.BasePath);

            return new UFormListReportResponseDto
            {
                FileName = _reportOptions.FileName,
                FileStream = stream
            };
        }
    }
}
