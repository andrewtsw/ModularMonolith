using MediatR;
using System;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Commands.PutGroupTaxpayerStores
{
    public class PutGroupTaxpayerStoresCommand : IRequest
    {
        public PutGroupTaxpayerStoresCommand(GroupTaxpayerStoresIdsDto dto)
        {
            GroupId = dto.GroupId;
            TaxpayerStoreIds = dto.TaxpayerStoreIds;
        }

        public Guid GroupId { get; }
        public int[] TaxpayerStoreIds { get; }
    }
}
