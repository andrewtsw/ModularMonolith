using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.TaxpayerStores.Commands.ImportTaxpayerStores;
using TCO.SNT.UseCases.TaxpayerStores.Queries;
using TCO.SNT.UseCases.TaxpayerStores.Queries.GetAllTaxpayerStores;
using TCO.SNT.UseCases.TaxpayerStores.Queries.GetUserTaxpayerStores;

namespace TCO.SNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxpayerStoreController : ControllerBase
    {
        private readonly ISender _sender;

        public TaxpayerStoreController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get only user taxpayer stores
        /// </summary>        
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<TaxpayerStoreSimpleDto>> GetUserTaxpayerStores(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetUserTaxpayerStoresQuery(), cancellationToken);
        }

        /// <summary>
        /// Get all taxpayer stores
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse, RoleType.Admin })]
        [HttpGet("alltaxpayerstores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<TaxpayerStoreSimpleDto>> GetAllTaxpayerStores(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetAllTaxpayerStoresQuery(), cancellationToken);
        }

        /// <summary>
        /// Import taxpayer stores
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<int> Import(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportTaxpayerStoresCommand(), cancellationToken);
        }
    }
}
