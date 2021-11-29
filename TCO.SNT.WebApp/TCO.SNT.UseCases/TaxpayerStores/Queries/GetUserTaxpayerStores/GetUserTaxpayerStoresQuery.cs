using MediatR;
using System.Collections.Generic;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetUserTaxpayerStores
{
    public class GetUserTaxpayerStoresQuery : IRequest<IReadOnlyList<TaxpayerStoreSimpleDto>>
    {
    }
}
