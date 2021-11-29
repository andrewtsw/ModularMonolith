using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.UseCases.Snt.Queries.SearchSntParticipantsByName
{
    internal class SearchSntParticipantsByNameQueryHandler : IRequestHandler<SearchSntParticipantsByNameQuery, IReadOnlyList<SntParticipantShortDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public SearchSntParticipantsByNameQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SntParticipantShortDto>> Handle(SearchSntParticipantsByNameQuery request, CancellationToken cancellationToken)
        {
            // Search customers by name and map to DTO
            var customersQuery = _context.SntCustomers
                .Where(x => x.Name.Contains(request.Name))
                .ProjectTo<SntParticipantShortDto>(_mapper.ConfigurationProvider);

            // Search sellers by name and map to DTO
            var sellersQuery = _context.SntSellers
                .Where(x => x.Name.Contains(request.Name))
                .ProjectTo<SntParticipantShortDto>(_mapper.ConfigurationProvider);

            return await customersQuery
                .Union(sellersQuery) // Union all customers and sellers
                .OrderByDescending(x => // Sort by subquery - get the latest LastUpdateDateUtc from all Snt's for seller/customer by Name
                    _context.SntInfos
                        .Where(info =>
                            _context.SntSellers
                                .Where(seller => seller.Name == x.Name)
                                .Select(seller => seller.SntId)
                                .Concat(
                                    _context.SntCustomers
                                        .Where(customer => customer.Name == x.Name)
                                        .Select(customer => customer.SntId))
                                .Contains(info.SntId))
                        .OrderByDescending(info => info.LastUpdateDateUtc)
                        .FirstOrDefault().LastUpdateDateUtc)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);
        }
    }
}
