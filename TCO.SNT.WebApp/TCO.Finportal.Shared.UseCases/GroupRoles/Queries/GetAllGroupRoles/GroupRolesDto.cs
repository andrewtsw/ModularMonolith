using System.Collections.Generic;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetAllGroupRoles
{
    public class GroupRolesDto
    {
        public GroupDescriptionDto Group { get; set; }

        public IReadOnlyList<RoleType> Roles { get; set; }

    }
}
