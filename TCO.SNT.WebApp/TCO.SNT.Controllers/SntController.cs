using AutoMapper;
using EsfApiSdk.Snt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus;
using TCO.SNT.UseCases.Snt.Commands.Import;
using TCO.SNT.UseCases.Snt.Commands.SaveDraft;
using TCO.SNT.UseCases.Snt.Commands.SendSnt;
using TCO.SNT.UseCases.Snt.Queries.GetSntFull;
using TCO.SNT.UseCases.Snt.Queries.GetSntList;
using TCO.SNT.UseCases.Snt.Queries.GetSntListReport;
using TCO.SNT.UseCases.Snt.Queries.GetSntParticipantByTin;
using TCO.SNT.UseCases.Snt.Queries.SearchSntParticipantsByName;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SntController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public SntController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Snt
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<SntListResponseDto> GetAll([FromQuery] SntListRequestDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetSntListQuery(dto), cancellationToken);
        }

        /// <summary>
        /// Get Snt full information
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<SntFullDto> Get(int id, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetSntFullQuery(id), cancellationToken);
        }

        /// <summary>
        /// Get SNT report by filters
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("get-snt-list-report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(typeof(FileStreamResult))]
        public async Task<IActionResult> GetSntListReport([FromQuery] SntListFilter filter, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetSntListReportQuery(filter, AppDomain.CurrentDomain.BaseDirectory), cancellationToken);
            return File(result.FileStream, MediaTypeNames.Application.Octet, result.FileName);
        }

        /// <summary>
        /// Revoke (Отзыв) Snt
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator })]
        [HttpPost("revoke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<SntSimpleDto> Revoke(RevokeSntDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new ChangeSntStatusCommand(_mapper.Map<ChangeSntStatusDto>(dto), SntActionType.REVOKE), cancellationToken);
        }

        /// <summary>
        /// Confirm Snt
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse })]
        [HttpPost("confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<SntSimpleDto> Confirm(ConfirmSntDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new ChangeSntStatusCommand(_mapper.Map<ChangeSntStatusDto>(dto), SntActionType.CONFIRM), cancellationToken);
        }

        /// <summary>
        /// Decline (Отклонение) Snt
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse })]
        [HttpPost("decline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<SntSimpleDto> Decline(DeclineSntDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new ChangeSntStatusCommand(_mapper.Map<ChangeSntStatusDto>(dto), SntActionType.DECLINE), cancellationToken);
        }

        /// <summary>
        /// Import Snt
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse })]
        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<ImportSntResultDto> Import(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportSntCommand(), cancellationToken);
        }

        /// <summary>
        /// Save draft
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly })]
        [HttpPost("save-draft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<int> SaveDraft(SntDraftDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new SaveSntDraftCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Send SNT to ESF portal
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator })]
        [HttpPost("send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task Send(SendSntDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new SendSntCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Get snt participant by tin
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("get-snt-participant-by-tin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<SntParticipantDto> GetSellerByTin(string tin, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetSntParticipantByTinQuery(tin), cancellationToken);
        }

        /// <summary>
        /// Search top snt participants by name
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("search-snt-participants-by-name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<SntParticipantShortDto>> SearchSntParticipantsByName(string name, int top, CancellationToken cancellationToken)
        {
            return _sender.Send(new SearchSntParticipantsByNameQuery(name, top), cancellationToken);
        }
    }
}
