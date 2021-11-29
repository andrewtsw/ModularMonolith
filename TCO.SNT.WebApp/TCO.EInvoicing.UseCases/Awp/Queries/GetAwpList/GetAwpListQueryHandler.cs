using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.UseCases.Awp.Extensions;
using TCO.EInvoicing.UseCases.Awp.Models;
using TCO.EInvoicing.UseCases.Awp.Queries;
using TCO.Finportal.Framework.UseCases;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.SNT.Common.Options;

namespace TCO.EInvoicing.UseCases.Awp.Queries.GetAwpList
{
    internal class GetSntListQueryHandler : IRequestHandler<GetAwpListQuery, AwpListResponseDto>
    {
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;                

        public GetSntListQueryHandler(IEInvoicingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;                        
        }

        public async Task<AwpListResponseDto> Handle(GetAwpListQuery request, CancellationToken cancellationToken)
        {
            var paging = new PagingModel(request.Dto.Paging);

            var query = await _context.Awps
                .ApplyFilter(request.Dto.Filter)
                .ApplySorting(request.Dto.Sorting)
                .ApplyPagingAsync(paging, cancellationToken);

            var awpList = await query
                .ProjectTo<AwpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);            

            return new AwpListResponseDto
            {
                Paging = paging,
                Awps = awpList
            };
        }
    }
}
