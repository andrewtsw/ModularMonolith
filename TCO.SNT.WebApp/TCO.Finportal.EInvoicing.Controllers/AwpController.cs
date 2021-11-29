using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsInitial;
using TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsRegular;
using TCO.EInvoicing.UseCases.Awp.Queries.GetAwpList;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.EInvoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwpController : ControllerBase
    {
        private readonly ISender _sender;

        public AwpController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Import awps
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-regular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<ImportAwpsResultDto> ImportAwpsRegular(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportAwpsRegularCommand(), cancellationToken);
        }

        /// <summary>
        /// Import awps
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-initial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<int> ImportAwpsInitial(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportAwpsInitialCommand(), cancellationToken);
        }

        /// <summary>
        /// Get all Awp
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadWrite})]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<AwpListResponseDto> GetAll([FromQuery] AwpListRequestDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetAwpListQuery(dto), cancellationToken);
        }
    }
}
