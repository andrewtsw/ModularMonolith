using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;
using TCO.Finportal.Shared.DataAccess.Interfaces;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetAllGroupRoles
{
    internal class GetAllGroupRolesQueryHandler : IRequestHandler<GetAllGroupRolesQuery, IReadOnlyList<GroupRolesDto>>
    {
        private readonly ISharedDbContext _context;
        private readonly IMsGraphService _msGraphUniversalService;

        public GetAllGroupRolesQueryHandler(ISharedDbContext context, IMsGraphService msGraphUniversalService)
        {
            _context = context;
            _msGraphUniversalService = msGraphUniversalService;
        }

        public async Task<IReadOnlyList<GroupRolesDto>> Handle(GetAllGroupRolesQuery request, CancellationToken cancellationToken)
        {
            var groupRoles = await _context.GroupRoles.ToListAsync(cancellationToken);

            var groupRolesTasks = groupRoles.GroupBy(q => q.GroupId)
              .Select(async q => new GroupRolesDto
              {
                  Group = new GroupDescriptionDto
                  {
                      Id = q.Key,
                      Name = await _msGraphUniversalService.GetAdGroupNameByIdAsync(q.Key, cancellationToken)
                  },
                  Roles = q.Select(r => r.Role).ToList()
              });

            return await Task.WhenAll(groupRolesTasks);
        }
    }
}
