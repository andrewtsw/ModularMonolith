using MediatR;
using System.Collections.Generic;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.Shared.Dto;

namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.GetMeasureUnits
{
    public class GetMeasureUnitsQuery : IRequest<IReadOnlyList<MeasureUnitDto>>
    {
    }
}
