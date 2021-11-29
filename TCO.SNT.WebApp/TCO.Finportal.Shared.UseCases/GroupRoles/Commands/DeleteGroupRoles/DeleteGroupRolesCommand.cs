using MediatR;
using System;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Commands.DeleteGroupRoles
{
    public class DeleteGroupRolesCommand : IRequest
    {
        public DeleteGroupRolesCommand(Guid groupId)
        {
            GroupId = groupId;
        }

        public Guid GroupId { get; }
    }
}
