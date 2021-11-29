using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetUserTaxpayerStores
{
    internal class GetUserTaxpayerStoresQueryHandler : IRequestHandler<GetUserTaxpayerStoresQuery, IReadOnlyList<TaxpayerStoreSimpleDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly TaxpayerStoreUserValidator _validator;

        public GetUserTaxpayerStoresQueryHandler(IDbContext context, IMapper mapper, TaxpayerStoreUserValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IReadOnlyList<TaxpayerStoreSimpleDto>> Handle(GetUserTaxpayerStoresQuery request, CancellationToken cancellationToken)
        {
            var userAllowedTaxpayerStoreIds = await _validator.GetUserAllowedTaxpayerStoreIdsAsync(cancellationToken);

            var stores = await _context.TaxpayerStores
                .Where(q => userAllowedTaxpayerStoreIds.Contains(q.Id))
                .ProjectTo<TaxpayerStoreSimpleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return stores;
        }
    }
}
