using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.Finportal.Shared.UseCases.GroupRoles.Commands.DeleteGroupRoles;
using TCO.Finportal.Shared.UseCases.GroupRoles.Commands.PutGroupRoles;
using TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetAllGroupRoles;
using TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetGroupRoles;
using TCO.SNT.Common.Roles;


namespace TCO.Finportal.Shared.Controllers.Admin
{
    [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class GroupRoleController : ControllerBase
    {
        private readonly ISender _sender;

        public GroupRoleController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get all groups with their roles
        /// </summary>
        [HttpGet("grouproles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<GroupRolesDto>> GetAllGroupRoles(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetAllGroupRolesQuery(), cancellationToken);
        }

        /// <summary>
        /// Get group roles
        /// </summary>
        [HttpGet("grouproles/{groupId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<RoleType>> GetGroupRoles(Guid groupId, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetGroupRolesQuery(groupId), cancellationToken);
        }

        /// <summary>
        /// Put new group role
        /// </summary>
        [HttpPut("grouproles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task PutGroupRoles(PutGroupRolesDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new PutGroupRolesCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Delete group roles
        /// </summary>
        [HttpDelete("grouproles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task DeleteGroupRoles(Guid groupId, CancellationToken cancellationToken)
        {
            return _sender.Send(new DeleteGroupRolesCommand(groupId), cancellationToken);
        }
    }
}
