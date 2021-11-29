using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.MSGraph.Queries.GetADGroupsByPattern;

namespace TCO.SNT.Controllers.Admin
{
    [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ISender _sender;

        public AdminController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get groups from AzureAD with names which matches pattern
        /// </summary>
        [HttpGet("searchgroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<AdGroupDto>> SearchGroup(string seek, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetADGroupsByPatternQuery(seek), cancellationToken);
        }
    }
}