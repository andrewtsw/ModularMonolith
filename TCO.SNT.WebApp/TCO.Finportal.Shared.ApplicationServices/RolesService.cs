using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.SNT.Common.Roles;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Shared.ApplicationServices
{
    public class RolesService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ISharedDbContext _sharedDbContext;

        public RolesService(
            ICurrentUserService currentUserService,
            ISharedDbContext sharedDbContext
            )
        {
            _currentUserService = currentUserService;
            _sharedDbContext = sharedDbContext;
        }

        public async Task<IReadOnlyList<RoleType>> GetUserRoles(CancellationToken cancellationToken)
        {
            var allGroupRoles = await _sharedDbContext.GroupRoles.ToListAsync(cancellationToken);

            var userGroups = allGroupRoles
                     .Select(q => q.GroupId)
                     .Distinct()
                     .Where(q => _currentUserService.IsInGroup(q));

            return allGroupRoles
                        .Where(q => userGroups.Contains(q.GroupId))
                        .Select(q => q.Role)
                        .Distinct()
                        .ToList();
        }

        public bool IsInRoles(RoleType[] roles)
        {
            var allRolesGroupIds = _sharedDbContext.GroupRoles
                .Where(q => roles.Contains(q.Role))
                .Select(q => q.GroupId)
                .ToList();

            return allRolesGroupIds.Any(groupId => _currentUserService.IsInGroup(groupId));
        }

        public bool IsInRole(RoleType role)
        {
            var allRoleGroupIds = _sharedDbContext.GroupRoles
               .Where(q => role == q.Role)
               .Select(q => q.GroupId)
               .ToList();

            return allRoleGroupIds.Any(groupId => _currentUserService.IsInGroup(groupId));
        }
    }
}
