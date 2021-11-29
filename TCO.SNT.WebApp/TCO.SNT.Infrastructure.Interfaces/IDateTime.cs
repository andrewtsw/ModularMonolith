using System;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
