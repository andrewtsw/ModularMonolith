using MediatR;
using System.Collections.Generic;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetAllTaxpayerStores
{
    public class GetAllTaxpayerStoresQuery : IRequest<IReadOnlyList<TaxpayerStoreSimpleDto>>
    {
    }
}
