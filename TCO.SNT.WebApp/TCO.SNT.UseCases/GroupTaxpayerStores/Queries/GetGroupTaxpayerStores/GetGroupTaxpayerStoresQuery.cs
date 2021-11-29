using MediatR;
using System;
using System.Collections.Generic;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetGroupTaxpayerStores
{
    public class GetGroupTaxpayerStoresQuery : IRequest<IReadOnlyList<TaxpayerStoreDescriptionDto>>
    {
        public GetGroupTaxpayerStoresQuery(Guid groupId)
        {
            GroupId = groupId;
        }

        public Guid GroupId { get; }
    }
}
