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

namespace TCO.SNT.UseCases.Currency.GetCurrency
{
    internal class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, List<CurrencyDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetCurrencyQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CurrencyDto>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _context.Currencies
                .OrderBy(o => o.Code)
                .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return currencies;
        }
    }
}
