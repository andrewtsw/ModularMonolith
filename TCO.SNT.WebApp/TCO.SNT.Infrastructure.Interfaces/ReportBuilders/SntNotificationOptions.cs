using System;

namespace TCO.SNT.Infrastructure.Interfaces
{
    public class SntNotificationOptions
    {
        public Guid AdGroupId { get; set; }

        public int DaysUntilDeadline { get; set; }
    }
}
