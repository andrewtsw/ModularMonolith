using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Balances.Extentions;
using TCO.SNT.UseCases.Extentions;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalances
{
    internal class GetBalancesQueryHandler : IRequestHandler<GetBalancesQuery, BalancesListResponseDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetBalancesQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BalancesListResponseDto> Handle(GetBalancesQuery request, CancellationToken cancellationToken)
        {
            var paging = new PagingModel(request.Dto.Paging);

            var query = await _context.Balances
                .ApplyFilter(request.Dto.Filter)
                .Where(x => x.IsActive)
                .ApplySorting(request.Dto.Sorting)
                .ApplyPagingAsync(paging, cancellationToken);

            var balances = await query
                .ProjectTo<BalanceSimpleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BalancesListResponseDto
            {
                Paging = paging,
                Balances = balances
            };
        }
    }
}
