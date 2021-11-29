using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Products.Queries.GetFavoriteProducts
{
    internal class GetFavoriteProductsQueryHandler : IRequestHandler<GetFavoriteProductsQuery, IReadOnlyList<FavoriteProductDto>>
    {
        private readonly IDbContext _context;

        public GetFavoriteProductsQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FavoriteProductDto>> Handle(GetFavoriteProductsQuery request, CancellationToken cancellationToken)
        {
            var query = from favorite in _context.FavoriteProducts
                        join product in _context.Products on favorite.ProductId equals product.Id
                        join parent in _context.Products on product.FixedParentId equals parent.FixedId
                        join grandParent in _context.Products on parent.FixedParentId equals grandParent.FixedId
                        select new
                        {
                            Id = product.Id,
                            Code = product.Code,
                            Name = product.NameRu,
                            Type = product.GsvsTypeCode,
                            ParentCode = parent.Code,
                            GrandParentCode = grandParent.Code 
                        };

            var products = await query.ToListAsync(cancellationToken);

            return products
                .Select(x => new FavoriteProductDto
                { 
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    GsvsTypeCode = x.Type,
                    CompositeCode = Product.ComposeFullGsvsCode(x.Type, x.Code, x.ParentCode, x.GrandParentCode)
                })
                .ToList();
        }
    }
}
