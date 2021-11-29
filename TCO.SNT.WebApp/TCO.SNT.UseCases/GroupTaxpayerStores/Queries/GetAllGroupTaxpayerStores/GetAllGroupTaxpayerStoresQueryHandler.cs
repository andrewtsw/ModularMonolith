using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetAllGroupTaxpayerStores
{
    internal class GetAllGroupTaxpayerStoresQueryHandler : IRequestHandler<GetAllGroupTaxpayerStoresQuery, IReadOnlyList<GroupTaxpayerStoresDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;
        private readonly IMsGraphService _msGraphUniversalService;

        public GetAllGroupTaxpayerStoresQueryHandler(IDbContext context, IMapper mapper, IMsGraphService msGraphUniversalService)
        {
            _mapper = mapper;
            _context = context;
            _msGraphUniversalService = msGraphUniversalService;
        }

        public async Task<IReadOnlyList<GroupTaxpayerStoresDto>> Handle(GetAllGroupTaxpayerStoresQuery request, CancellationToken cancellationToken)
        {
            var allGroupTaxpayerStores = await _context.GroupTaxpayerStores
                .Include(q => q.TaxpayerStore)
                .ToListAsync(cancellationToken);

            var taxpayerStoresTasks = allGroupTaxpayerStores
                .GroupBy(q => q.GroupId)
                .Select(async q => new GroupTaxpayerStoresDto
                {
                    Group = new GroupDescriptionDto
                    {
                        Id = q.Key,
                        Name = await _msGraphUniversalService.GetAdGroupNameByIdAsync(q.Key, cancellationToken)
                    },
                    TaxpayerStores = q.Select(r => _mapper.Map<TaxpayerStoreDescriptionDto>(r.TaxpayerStore)).ToList()
                });

            return await Task.WhenAll(taxpayerStoresTasks);
        }
    }
}
