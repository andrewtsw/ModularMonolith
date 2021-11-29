using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Invoices.Commands.ImportInvoicesInitial;
using TCO.EInvoicing.UseCases.Invoices.Commands.ImportInvoicesRegular;
using TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice;
using TCO.EInvoicing.UseCases.Invoices.Commands.SendInvoice;
using TCO.EInvoicing.UseCases.Invoices.Dto;
using TCO.EInvoicing.UseCases.Invoices.Queries.GetOutboundInvoiceById;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.EInvoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ISender _sender;

        public InvoicesController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Import invoices initial
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-initial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<ImportInvoicesInitialResultDto> ImportInvoicesInitial(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportInvoicesInitialCommand(), cancellationToken);
        }

        /// <summary>
        /// Import invoices regular
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-regular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<ImportInvoicesRegularResultDto> ImportInvoicesRegular(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportInvoicesRegularCommand(), cancellationToken);
        }

        /// <summary>
        /// Get all inboind invoices
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ApReadOnly, RoleType.ApReadWrite })]
        [HttpGet("inbound")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<string>> SearchInboundInvoices(string filter, CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<string>>(new[] { filter });
        }

        /// <summary>
        /// Get inboind invoice by id
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ApReadOnly, RoleType.ApReadWrite })]
        [HttpGet("inbound/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<int> GetInboundInvoice(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(id);
        }

        /// <summary>
        /// Confirm inbound invoice
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ApReadWrite })]
        [HttpPost("inbound/{id}/confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<int> Confirm(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(id);
        }

        /// <summary>
        /// Decline inbound invoice
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ApReadWrite })]
        [HttpPost("inbound/{id}/decline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<int> Decline(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(id);
        }

        /// <summary>
        /// Get all outbound invoices
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadOnly, RoleType.ArReadWrite })]
        [HttpGet("outbound")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<string>> SearchOutboundInvoices(string filter, CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<string>>(new[] { filter });
        }

        /// <summary>
        /// Get outbound invoice by id
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadOnly, RoleType.ArReadWrite })]
        [HttpGet("outbound/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<InvoiceFullDto> GetOutboundInvoice(int id, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetOutboundInvoiceByIdQuery(id), cancellationToken);
        }

        /// <summary>
        /// Get outbound invoice draft
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadWrite })]
        [HttpPost("outbound/save-draft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<int> SaveDraft(InvoiceDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new SaveDraftInvoiceCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Send outbound invoice
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadWrite })]
        [HttpPost("outbound/send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task Send(SendInvoiceDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new SendInvoiceCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Revoke outbound invoice
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ArReadWrite })]
        [HttpPost("outbound/{id}/revoke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<int> Revoke(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(id);
        }

        /// <summary>
        /// Generate report
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.ApReadOnly, RoleType.ApReadWrite, RoleType.ArReadOnly, RoleType.ArReadWrite })]
        [HttpGet("report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<string> BuildReport(string parameters, CancellationToken cancellationToken)
        {
            return Task.FromResult(parameters);
        }        
    }
}
