using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Currency.Shared.Dto;

namespace TCO.SNT.UseCases.Currency.GetFavouriteCurrency
{
    internal class GetFavouriteCurrencyQueryHandler : IRequestHandler<GetFavouriteCurrencyQuery, IReadOnlyList<CurrencyDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetFavouriteCurrencyQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CurrencyDto>> Handle(GetFavouriteCurrencyQuery request, CancellationToken cancellationToken)
        {
            var topCurrencies = await _context.FavouriteCurrencies
                .OrderBy(o => o.SortOrder)
                .Select(x => x.Currency)
                .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return topCurrencies;
            
        }
    }
}
