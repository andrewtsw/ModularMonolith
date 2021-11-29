using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Products.Commands.AddFavoriteProduct
{
    internal class AddFavoriteProductCommandHandler : AsyncRequestHandler<AddFavoriteProductCommand>
    {
        private readonly IDbContext _context;

        public AddFavoriteProductCommandHandler(IDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(AddFavoriteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .SingleOrExceptionAsync(x => x.Code == request.Code, cancellationToken);

            if (!product.IsAvailableForSnt())
            {
                throw new ValidationException("Product not available for SNT!");
            }

            var favoriteProduct = await _context.FavoriteProducts
                .SingleOrDefaultAsync(x => x.ProductId == product.Id, cancellationToken);

            if (favoriteProduct == null)
            {
                _context.FavoriteProducts.Add(new FavoriteProduct { Product = product });
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
