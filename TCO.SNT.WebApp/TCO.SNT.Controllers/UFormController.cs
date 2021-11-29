using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.UForms.Commands.ImportUForms;
using TCO.SNT.UseCases.UForms.Commands.SaveBalanceUForm;
using TCO.SNT.UseCases.UForms.Commands.SaveManufactureUForm;
using TCO.SNT.UseCases.UForms.Commands.SaveMovementUForm;
using TCO.SNT.UseCases.UForms.Commands.SaveWriteOffUForm;
using TCO.SNT.UseCases.UForms.Commands.SendUForm;
using TCO.SNT.UseCases.UForms.Queries.GetAllUForms;
using TCO.SNT.UseCases.UForms.Queries.GetUFormFull;
using TCO.SNT.UseCases.UForms.Queries.GetUFormListReport;
using TCO.SNT.UseCases.UForms.Queries.Shared;

namespace TCO.SNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UFormController : ControllerBase
    {
        private readonly ISender _sender;

        public UFormController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get all forms
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<UFormListResponseDto> GetAllForms([FromQuery] UFormListRequestDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetAllUFormsQuery(dto), cancellationToken);
        }

        /// <summary>
        /// Get form
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<UFormFullDto> Get(int id, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetUFormFullQuery(id), cancellationToken);
        }

        /// <summary>
        /// Get Uform list report by filters
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("get-uform-list-report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(typeof(FileStreamResult))]
        public async Task<IActionResult> GetUFormListReport([FromQuery] UFormListReportRequestDto dto, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetUFormListReportQuery(dto, AppDomain.CurrentDomain.BaseDirectory), cancellationToken);
            return File(result.FileStream, MediaTypeNames.Application.Octet, result.FileName);
        }

        /// <summary>
        /// Save manufacture draft
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly })]
        [HttpPost("save-manufacture-draft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<int> SaveManufactureDraft([Required] ManufactureUFormDto form, CancellationToken cancellationToken)
        {
            return _sender.Send(new SaveManufactureUFormCommand(form), cancellationToken);
        }

        /// <summary>
        /// Save write-off draft
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpPost("save-writeoff-draft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<int> SaveWriteOffDraft([Required] WriteOffUFormDto form, CancellationToken cancellationToken)
        {
            return _sender.Send(new SaveWriteOffUFormCommand(form), cancellationToken);
        }

        /// <summary>
        /// Save movement draft
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly })]
        [HttpPost("save-movement-draft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<int> SaveMovementDraft([Required] MovementUFormDto form, CancellationToken cancellationToken)
        {
            return _sender.Send(new SaveMovementUFormCommand(form), cancellationToken);
        }

        /// <summary>
        /// Cancel UForm
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator })]
        [HttpPost("cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task Cancel(CancellationToken cancellationToken)
        {
            //TODO implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save balance draft
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly })]
        [HttpPost("save-balance-draft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<int> SaveBalanceDraft([Required] BalanceUFormDto form, CancellationToken cancellationToken)
        {
            return _sender.Send(new SaveBalanceUFormCommand(form), cancellationToken);
        }

        /// <summary>
        /// Send form to ESF portal
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse })]
        [HttpPost("send/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task Send(int id, CancellationToken cancellationToken)
        {
            return _sender.Send(new SendUFormCommand(id), cancellationToken);
        }

        /// <summary>
        /// Import UForms
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse })]
        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<ImportUFormsResultDto> Import(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportUFormsCommand(), cancellationToken);
        }

        // TODO: Add method - remove draft
    }
}
