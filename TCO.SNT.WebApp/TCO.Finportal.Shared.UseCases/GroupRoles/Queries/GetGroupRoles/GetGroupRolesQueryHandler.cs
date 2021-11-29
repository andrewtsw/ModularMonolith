using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetGroupRoles
{
    internal class GetGroupRolesQueryHandler : IRequestHandler<GetGroupRolesQuery, IReadOnlyList<RoleType>>
    {
        private readonly ISharedDbContext _context;

        public GetGroupRolesQueryHandler(ISharedDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<RoleType>> Handle(GetGroupRolesQuery request, CancellationToken cancellationToken)
        {
            return await _context.GroupRoles
                .Where(q => q.GroupId == request.GroupId)
                .Select(q => q.Role)
                .ToListAsync(cancellationToken);
        }
    }
}
