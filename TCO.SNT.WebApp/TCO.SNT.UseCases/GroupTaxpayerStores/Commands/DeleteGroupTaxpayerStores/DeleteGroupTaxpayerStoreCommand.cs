using MediatR;
using System;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Commands.DeleteGroupTaxpayerStores
{
    public class DeleteGroupTaxpayerStoreCommand : IRequest
    {
        public DeleteGroupTaxpayerStoreCommand(Guid groupId)
        {
            GroupId = groupId;
        }

        public Guid GroupId { get; }
    }
}
