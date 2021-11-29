using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.Shared.Dto;

namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.GetFavouriteMeasureUnits
{
    internal class GetFavouriteMeasureUnitsQueryHandler : IRequestHandler<GetFavouriteMeasureUnitsQuery, IReadOnlyList<MeasureUnitDto>>
    {
        private readonly ISharedDbContext _context;

        public GetFavouriteMeasureUnitsQueryHandler(ISharedDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> Handle(GetFavouriteMeasureUnitsQuery request, CancellationToken cancellationToken)
        {
            var query = from favorite in _context.FavouriteMeasureUnits
                        join measure in _context.MeasureUnits on favorite.MeasureUnitId equals measure.Id
                        select new MeasureUnitDto
                        {
                            Id = measure.Id,
                            Code = measure.Code,
                            Name = measure.NameRu,
                        };

            var favourites = await query.ToListAsync(cancellationToken);

            return favourites;
        }
    }
}
