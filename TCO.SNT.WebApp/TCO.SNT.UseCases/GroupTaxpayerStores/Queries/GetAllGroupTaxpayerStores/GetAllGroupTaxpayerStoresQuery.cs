using MediatR;
using System.Collections.Generic;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetAllGroupTaxpayerStores
{
    public class GetAllGroupTaxpayerStoresQuery : IRequest<IReadOnlyList<GroupTaxpayerStoresDto>>
    {
    }
}
