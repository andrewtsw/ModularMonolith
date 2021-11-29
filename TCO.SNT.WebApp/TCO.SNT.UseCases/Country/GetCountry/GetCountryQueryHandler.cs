using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Country.Shared;
using System.Linq;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TCO.SNT.UseCases.Country.GetCountry
{
    internal class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, IReadOnlyList<CountryDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetCountryQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var countries = await _context.Countries
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .OrderBy(o => o.Name)
                .ToListAsync(cancellationToken);

            return countries;
        }
    }
}
