using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.Shared.Dto;

namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.GetMeasureUnits
{
    internal class GetMeasureUnitsQueryHandler : IRequestHandler<GetMeasureUnitsQuery, IReadOnlyList<MeasureUnitDto>>
    {
        private readonly ISharedDbContext _context;
        private readonly IMapper _mapper;

        public GetMeasureUnitsQueryHandler(ISharedDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> Handle(GetMeasureUnitsQuery request, CancellationToken cancellationToken)
        {
            var measureUnits = await _context.MeasureUnits
                .OrderBy(x => x.Code)
                .ProjectTo<MeasureUnitDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return measureUnits;
        }
    }
}
