using System;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }

        bool IsInGroup(Guid groupId);
    }
}
