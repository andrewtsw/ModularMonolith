using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetGroupTaxpayerStores
{
    internal class GetGroupTaxpayerStoresQueryHandler : IRequestHandler<GetGroupTaxpayerStoresQuery, IReadOnlyList<TaxpayerStoreDescriptionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public GetGroupTaxpayerStoresQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TaxpayerStoreDescriptionDto>> Handle(GetGroupTaxpayerStoresQuery request, CancellationToken cancellationToken)
        {
            var taxpayerStores = await _context.GroupTaxpayerStores
                                        .Where(q => q.GroupId == request.GroupId)
                                        .Select(q => q.TaxpayerStore)
                                        .ToListAsync(cancellationToken);

            return taxpayerStores.Select(q => _mapper.Map<TaxpayerStoreDescriptionDto>(q)).ToList();
        }
    }
}
