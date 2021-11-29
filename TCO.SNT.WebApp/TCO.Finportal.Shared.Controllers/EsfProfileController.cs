using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.Finportal.Shared.Controllers.EsfProfileDtos;
using TCO.Finportal.Shared.Controllers.Extentions;
using TCO.Finportal.Shared.UseCases.Users.Commands.SetPassword;
using TCO.Finportal.Shared.UseCases.Users.Commands.SetUsername;
using TCO.Finportal.Shared.UseCases.Users.Commands.UploadAuthCertificate;
using TCO.Finportal.Shared.UseCases.Users.Commands.UploadSignCertificate;
using TCO.Finportal.Shared.UseCases.Users.Queries.GetEsfUserProfile;
using TCO.Finportal.Shared.UseCases.Users.Queries.GetTestConnection;
using TCO.Finportal.Shared.UseCases.Users.Shared;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.Controllers
{
    [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse, RoleType.Admin, RoleType.ApReadWrite, RoleType.ArReadWrite })]
    [Route("api/[controller]")]
    [ApiController]
    public class EsfProfileController : ControllerBase
    {
        private readonly ISender _sender;

        public EsfProfileController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get user ESF profile
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<EsfUserProfileDto> Get(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetEsfUserProfileQuery(), cancellationToken);
        }

        /// <summary>
        /// Test connection to ESF
        /// </summary>
        [HttpGet("test-connection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<TestConnectionResponseDto> TestConnection(CancellationToken cancellationToken)
        {
            return _sender.Send(new TestConnectionQuery(), cancellationToken);
        }

        /// <summary>
        /// Set user name
        /// </summary>
        [HttpPost("username")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<EsfUserProfileDto> SaveUsername([Required] string username, CancellationToken cancellationToken)
        {
            return _sender.Send(new SetUsernameCommand(username), cancellationToken);
        }

        /// <summary>
        /// Set user password
        /// </summary>
        [HttpPost("password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<EsfUserProfileDto> SavePassword([Required] string password, CancellationToken cancellationToken)
        {
            return _sender.Send(new SetPasswordCommand(password), cancellationToken);
        }

        /// <summary>
        /// Upload user auth certificate
        /// </summary>
        [HttpPost("auth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EsfUserProfileDto> UploadAuthCertificateAsync([FromForm][Required] UploadCerteficateDto dto, CancellationToken cancellationToken)
        {
            var bytes = await dto.File.GetFileBytesAsync(cancellationToken);
            return await _sender.Send(new UploadAuthCertificateCommand(bytes, dto.Password), cancellationToken);
        }

        /// <summary>
        /// Upload user sign certificate
        /// </summary>
        [HttpPost("sign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<EsfUserProfileDto> UploadSignCertificateAsync([FromForm][Required] UploadCerteficateDto dto, CancellationToken cancellationToken)
        {
            var bytes = await dto.File.GetFileBytesAsync(cancellationToken);
            return await _sender.Send(new UploadSignCertificateCommand(bytes, dto.Password), cancellationToken);
        }
    }
}
