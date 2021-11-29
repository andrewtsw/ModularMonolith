using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Extensions;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Commands.DeleteGroupTaxpayerStores
{
    internal class DeleteGroupTaxpayerStoresCommandHandler : AsyncRequestHandler<DeleteGroupTaxpayerStoreCommand>
    {
        private readonly IDbContext _context;

        public DeleteGroupTaxpayerStoresCommandHandler(IDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteGroupTaxpayerStoreCommand request, CancellationToken cancellationToken)
        {
            var itemsToDelete = await _context.GroupTaxpayerStores
                        .Where(q => q.GroupId == request.GroupId)
                        .ToListAsync(cancellationToken);

            if (!itemsToDelete.IsNullOrEmpty())
            {
                _context.GroupTaxpayerStores.RemoveRange(itemsToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
