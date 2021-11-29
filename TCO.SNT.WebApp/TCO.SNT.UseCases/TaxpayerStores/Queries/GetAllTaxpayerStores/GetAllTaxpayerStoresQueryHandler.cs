using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetAllTaxpayerStores
{
    internal class GetAllTaxpayerStoresQueryHandler : IRequestHandler<GetAllTaxpayerStoresQuery, IReadOnlyList<TaxpayerStoreSimpleDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTaxpayerStoresQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TaxpayerStoreSimpleDto>> Handle(GetAllTaxpayerStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = await _context.TaxpayerStores
                .ProjectTo<TaxpayerStoreSimpleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return stores;
        }
    }
}
