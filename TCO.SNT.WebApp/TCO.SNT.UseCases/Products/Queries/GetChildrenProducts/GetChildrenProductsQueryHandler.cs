using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Products.Queries.Shared;

namespace TCO.SNT.UseCases.Products.Queries.GetChildrenProducts
{
    internal class GetChildrenProductsQueryHandler : IRequestHandler<GetChildrenProductsQuery, IReadOnlyList<ProductDto>>
    {
        private const int MaxChildrenProducts = 100;

        private readonly IDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IMapper _mapper;

        public GetChildrenProductsQueryHandler(IDbContext context, IDateTime dateTime, IMapper mapper)
        {
            _context = context;
            _dateTime = dateTime;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductDto>> Handle(GetChildrenProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.EndDateUtc == null || x.EndDateUtc >= _dateTime.UtcNow)
                .Where(x => x.FixedParentId == request.FixedId)
                .OrderBy(x => x.Code)
                .Take(MaxChildrenProducts)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
