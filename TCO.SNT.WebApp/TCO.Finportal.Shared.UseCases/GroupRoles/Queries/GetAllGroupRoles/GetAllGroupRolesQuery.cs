using MediatR;
using System.Collections.Generic;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Queries.GetAllGroupRoles
{
    public class GetAllGroupRolesQuery : IRequest<IReadOnlyList<GroupRolesDto>>
    {
    }
}
