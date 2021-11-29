using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.Snt.Extensions;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntList
{
    internal class GetSntListQueryHandler : IRequestHandler<GetSntListQuery, SntListResponseDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly ErrorHelper _errorHelper;
        private readonly CompanyOptions _companyOptions;

        public GetSntListQueryHandler(IDbContext context, IMapper mapper, ErrorHelper errorHelper, IOptions<CompanyOptions> companyOptions)
        {
            _context = context;
            _mapper = mapper;
            _errorHelper = errorHelper;
            _companyOptions = companyOptions.Value;
        }

        public async Task<SntListResponseDto> Handle(GetSntListQuery request, CancellationToken cancellationToken)
        {
            var paging = new PagingModel(request.Dto.Paging);

            var query = await _context.Snts
                .ApplyFilter(request.Dto.Filter, _companyOptions)
                .ApplySorting(request.Dto.Sorting)
                .ApplyPagingAsync(paging, cancellationToken);

            var sntList = await query
                .ProjectTo<SntSimpleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            await _errorHelper.FillErrorDescriptionAsync(sntList, cancellationToken);

            return new SntListResponseDto
            {
                Paging = paging,
                Snts = sntList
            };
        }
    }
}
