using System;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.Infrastructure.Implementation
{
    internal class MachineDateTime : IDateTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
