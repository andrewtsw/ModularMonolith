using MediatR;
using System.Collections.Generic;

namespace TCO.SNT.UseCases.Products.Queries.GetFavoriteProducts
{
    public class GetFavoriteProductsQuery : IRequest<IReadOnlyList<FavoriteProductDto>>
    {
    }
}
