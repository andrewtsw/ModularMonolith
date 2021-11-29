using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Commands.ImportMeasureUnits;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.GetFavouriteMeasureUnits;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.GetMeasureUnits;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.Shared.Dto;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        private readonly ISender _sender;

        public DictionariesController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get measure units
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] 
        { 
            RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse,
            RoleType.ApReadOnly, RoleType.ApReadWrite, RoleType.ArReadOnly, RoleType.ArReadWrite
        })]
        [HttpGet("measure-units")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<MeasureUnitDto>> GetMeasureUnits(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetMeasureUnitsQuery(), cancellationToken);
        }

        /// <summary>
        /// Get favourite measure units
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] 
        { 
            RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse,
            RoleType.ApReadOnly, RoleType.ApReadWrite, RoleType.ArReadOnly, RoleType.ArReadWrite
        })]
        [HttpGet("favourite-measure-units")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<MeasureUnitDto>> GetFavouriteMeasureUnits(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetFavouriteMeasureUnitsQuery(), cancellationToken);
        }

        /// <summary>
        /// Import measure units
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-measure-units")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<ImportMeasureUnitsResultDto> ImportMeasureUnits(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportMeasureUnitsCommand(), cancellationToken);
        }
    }
}
