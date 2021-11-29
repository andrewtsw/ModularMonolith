using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.Finportal.Infrastructure.MsGraph.Interfaces
{
    public interface IMsGraphService
    {
        Task<IReadOnlyList<Guid>> GetUserParticipantAdGroups(IEnumerable<Guid> groupIds, Guid userId, CancellationToken cancellationToken);

        Task<IReadOnlyList<MsGraphUser>> GetAdGroupMembersAsync(Guid groupId, CancellationToken cancellationToken);

        Task<IReadOnlyList<AdGroupDto>> SearchAdGroupsByPatternAsync(string seek, CancellationToken cancellationToken);

        Task<string> GetAdGroupNameByIdAsync(Guid groupId, CancellationToken cancellationToken);
    }
}