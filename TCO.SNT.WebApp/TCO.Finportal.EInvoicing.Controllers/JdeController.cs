using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Invoices.Commands.ImportJdeArInvoices;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.EInvoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JdeController : ControllerBase
    {
        private readonly ISender _sender;

        public JdeController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Imports jde ar invoices
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-jde-ar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<ImportJdeArInvoicesResultDto> ImportJdeArInvoices(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportJdeArInvoicesCommand(), cancellationToken);
        } 
    }
}
