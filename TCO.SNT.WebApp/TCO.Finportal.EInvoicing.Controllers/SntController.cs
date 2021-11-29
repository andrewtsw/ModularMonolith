using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.Contract;
using TCO.SNT.UseCases.Snt.Queries.GetSntList;

namespace TCO.Finportal.EInvoicing.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SntController : ControllerBase
    {
        private readonly ISntModuleContract _sntModuleContract;

        public SntController(ISntModuleContract sntModuleContract)
        {
            _sntModuleContract = sntModuleContract;
        }

        /// <summary>
        /// Get snt list
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadWrite })]
        [HttpGet("get-snt-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<SntListResponseDto> GetSntList([FromQuery] SntListRequestDto dto, CancellationToken cancellationToken)
        {
            return await _sntModuleContract.GetSntList(dto, cancellationToken);
        }
    }
}
