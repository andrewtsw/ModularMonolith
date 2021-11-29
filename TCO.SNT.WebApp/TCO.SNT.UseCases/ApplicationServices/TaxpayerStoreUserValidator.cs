using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities.Exceptions;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.UseCases.ApplicationServices
{
    internal class TaxpayerStoreUserValidator
    {
        private readonly IDbContext _context;
        private readonly IMsGraphService _msGraphUniversalService;
        private readonly ICurrentUserService _currentUserService;

        public TaxpayerStoreUserValidator(IDbContext context,
            IMsGraphService msGraphUniversalService,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _msGraphUniversalService = msGraphUniversalService;
            _currentUserService = currentUserService;
        }

        public async Task ThrowExceptionIfTaxpayerStoreForbiddenForUserAsync(int taxpayerStoreId, CancellationToken cancellationToken)
        {
            var allowedIds = await GetUserAllowedTaxpayerStoreIdsAsync(cancellationToken);
            if (!allowedIds.Any(q => q == taxpayerStoreId))
            {
                throw new ForbiddenException($"TaxpayerStore {taxpayerStoreId} is forbidden for user [{_currentUserService.UserId}]");
            }
        }

        public async Task<int[]> GetUserAllowedTaxpayerStoreIdsAsync(CancellationToken cancellationToken)
        {
            var allTaxpayerStoreGroups = await _context.GroupTaxpayerStores
                                                .Select(q => q.GroupId)
                                                .Distinct()
                                                .ToListAsync(cancellationToken);

            var userAdGroupIds = await _msGraphUniversalService.GetUserParticipantAdGroups(allTaxpayerStoreGroups, _currentUserService.UserId, cancellationToken);

            return await _context.GroupTaxpayerStores
                                      .Where(q => userAdGroupIds.Contains(q.GroupId))
                                      .Select(q => q.TaxpayerStoreId)
                                      .Distinct()
                                      .ToArrayAsync(cancellationToken);
        }

        public async Task<int[]> ExtractOnlyAllowedTaxpayerStoreIdsAsync(int[] taxpayerStoreIds, CancellationToken cancellationToken)
        {
            var allowedIds = await GetUserAllowedTaxpayerStoreIdsAsync(cancellationToken);
            return taxpayerStoreIds.Intersect(allowedIds).ToArray();
        }
    }
}
