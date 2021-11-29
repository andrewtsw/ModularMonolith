using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Products.Queries.Shared;

namespace TCO.SNT.UseCases.Products.Queries.SearchProducts
{
    public class SearchProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        public SearchProductsQuery(ProductFilter filter)
        {
            Filter = filter;
        }

        public ProductFilter Filter { get; }

    }
}
