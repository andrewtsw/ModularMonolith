using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.Balances.Commands.FixBalancesImportKey;
using TCO.SNT.UseCases.Balances.Commands.ImportBalancesInitial;
using TCO.SNT.UseCases.Balances.Commands.ImportBalancesRegular;
using TCO.SNT.UseCases.Balances.Commands.ValidateBalances;
using TCO.SNT.UseCases.Balances.Queries.GetBalanceReport;
using TCO.SNT.UseCases.Balances.Queries.GetBalances;

namespace TCO.SNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly ISender _sender;

        public BalanceController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get all balances
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<BalancesListResponseDto> GetAll([FromQuery] BalancesListRequestDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetBalancesQuery(dto), cancellationToken);
        }

        /// <summary>
        /// Get Balance report by filters
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("get-balance-list-report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(typeof(FileStreamResult))]
        public async Task<IActionResult> GetBalanceListReport([FromQuery] BalanceListReportRequestDto dto, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetBalanceReportQuery(dto, AppDomain.CurrentDomain.BaseDirectory), cancellationToken);
            return File(result.FileStream, MediaTypeNames.Application.Octet, result.FileName);
        }

        /// <summary>
        /// Import balances regular
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.TCOWarehouse })]
        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<ImportBalancesRegularResultDto> ImportBalances(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportBalancesRegularCommand { ProcessUndistributedStore = true }, cancellationToken);
        }

        /// <summary>
        /// Import balances initial
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-initial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<int> ImportBalancesInitial(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportBalancesInitialCommand(), cancellationToken);
        }

        /// <summary>
        /// Import balances initial
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("fix-import-key")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<FixBalancesImportKeyResultDto> FixBalancesImportKey(CancellationToken cancellationToken)
        {
            return _sender.Send(new FixBalancesImportKeyCommand(), cancellationToken);
        }

        /// <summary>
        /// Validate balances
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<string> ValidateBalances(long? storeId, ValidateBalanceDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new ValidateBalancesCommand(storeId, dto), cancellationToken);
        }
    }
}
