using MediatR;
using System;
using System.Collections.Generic;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetGroupRoles
{
    public class GetGroupRolesQuery : IRequest<IReadOnlyList<RoleType>>
    {
        public GetGroupRolesQuery(Guid groupId)
        {
            GroupId = groupId;
        }

        public Guid GroupId { get; }
    }
}
