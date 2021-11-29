using MediatR;
using AutoMapper;
using TCO.SNT.UseCases.Country.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TCO.SNT.DataAccess.Interfaces;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace TCO.SNT.UseCases.Country.GetFavouriteCountry
{
    internal class GetFavouriteCountryQueryHandler : IRequestHandler<GetFavouriteCountryQuery, IReadOnlyList<CountryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public GetFavouriteCountryQueryHandler(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<IReadOnlyList<CountryDto>> Handle(GetFavouriteCountryQuery request, CancellationToken cancellationToken)
        {
            var topCurrenceis = await _context.FavouriteCountries
                .OrderBy(o => o.SortOrder)
                .Select(o => o.Country)
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return topCurrenceis;
        }
    }
}
