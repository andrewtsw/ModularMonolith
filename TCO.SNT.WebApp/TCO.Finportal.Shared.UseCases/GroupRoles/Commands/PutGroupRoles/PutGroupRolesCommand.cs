using MediatR;
using System;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Commands.PutGroupRoles
{
    public class PutGroupRolesCommand : IRequest
    {
        public PutGroupRolesCommand(PutGroupRolesDto dto)
        {
            GroupId = dto.GroupId;
            Roles = dto.Roles;
        }

        public Guid GroupId { get; }

        public RoleType[] Roles { get; }
    }
}
