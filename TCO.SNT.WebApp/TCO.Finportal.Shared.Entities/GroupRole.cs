using System;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.Entities
{
    public class GroupRole : AuditableEntity
    {
        public Guid GroupId { get; set; }

        public RoleType Role { get; set; }
    }
}
