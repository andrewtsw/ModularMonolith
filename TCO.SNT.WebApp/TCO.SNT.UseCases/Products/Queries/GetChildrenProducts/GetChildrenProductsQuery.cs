using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Products.Queries.Shared;

namespace TCO.SNT.UseCases.Products.Queries.GetChildrenProducts
{
    public class GetChildrenProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        public GetChildrenProductsQuery(long fixedId)
        {
            FixedId = fixedId;
        }

        public long FixedId { get; }
    }
}
