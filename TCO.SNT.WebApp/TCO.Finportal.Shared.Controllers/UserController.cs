using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.Finportal.Shared.UseCases.Users.Queries.GetUserProfile;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.Controllers
{
    [RoleAuthorize(RoleTypes = new RoleType[] 
    { 
        RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse, 
        RoleType.Admin, 
        RoleType.ApReadOnly, RoleType.ApReadWrite, RoleType.ArReadOnly, RoleType.ArReadWrite
    })]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get current user profile
        /// </summary>
        [HttpGet("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<UserProfileDto> GetUserProfile(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetUserProfileQuery(), cancellationToken);
        }
    }
}
