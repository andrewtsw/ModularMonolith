using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Commands.PutGroupTaxpayerStores
{

    internal class PutGroupTaxpayerStoresCommandHandler : AsyncRequestHandler<PutGroupTaxpayerStoresCommand>
    {
        private readonly IDbContext _context;

        public PutGroupTaxpayerStoresCommandHandler(IDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(PutGroupTaxpayerStoresCommand request, CancellationToken cancellationToken)
        {
            var oldItems = await _context.GroupTaxpayerStores
                .Where(q => q.GroupId == request.GroupId)
                .ToListAsync(cancellationToken);

            if (!oldItems.IsNullOrEmpty())
            {
                _context.GroupTaxpayerStores.RemoveRange(oldItems);
            }

            var newItems = request.TaxpayerStoreIds.Select(q => new GroupTaxpayerStore
            {
                GroupId = request.GroupId,
                TaxpayerStoreId = q,
            });

            _context.GroupTaxpayerStores.AddRange(newItems);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}