using System;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Commands.PutGroupRoles
{
    public class PutGroupRolesDto
    {
        public Guid GroupId { get; set; }

        [Required, MinLength(1)]
        public RoleType[] Roles { get; set; }
    }
}
