using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.GroupTaxpayerStores.Commands;
using TCO.SNT.UseCases.GroupTaxpayerStores.Commands.DeleteGroupTaxpayerStores;
using TCO.SNT.UseCases.GroupTaxpayerStores.Commands.PutGroupTaxpayerStores;
using TCO.SNT.UseCases.GroupTaxpayerStores.Queries;
using TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetAllGroupTaxpayerStores;
using TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetGroupTaxpayerStores;

namespace TCO.SNT.Controllers.Admin
{
    [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class GroupTaxpayerStoreController : ControllerBase
    {
        private readonly ISender _sender;

        public GroupTaxpayerStoreController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get all groups with their taxpayer stores
        /// </summary>
        [HttpGet("grouptaxpayerstores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<GroupTaxpayerStoresDto>> GetAllGroupTaxpayerStores(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetAllGroupTaxpayerStoresQuery(), cancellationToken);
        }

        /// <summary>
        /// Get group taxpayer stores
        /// </summary>
        [HttpGet("grouptaxpayerstores/{groupId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<TaxpayerStoreDescriptionDto>> GetGroupTaxpayerStores(Guid groupId, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetGroupTaxpayerStoresQuery(groupId), cancellationToken);
        }

        /// <summary>
        /// Put group taxpayer stores
        /// </summary>
        [HttpPut("grouptaxpayerstores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task PutGroupTaxpayerStores(GroupTaxpayerStoresIdsDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new PutGroupTaxpayerStoresCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Delete group access for all taxpayer stores
        /// </summary>
        [HttpDelete("grouptaxpayerstore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task DeleteGroupTxpayerStore(Guid groupId, CancellationToken cancellationToken)
        {
            return _sender.Send(new DeleteGroupTaxpayerStoreCommand(groupId), cancellationToken);
        }
    }
}