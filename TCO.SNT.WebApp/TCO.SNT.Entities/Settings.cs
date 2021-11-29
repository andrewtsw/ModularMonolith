using System;

namespace TCO.SNT.Entities
{
    public class Settings
    {
        public static readonly DateTime MinDate = new DateTime(2019, 1, 1);

        public int Id { get; set; }

        public long GsvsLastChangeId { get; set; }

        public DateTimeOffset UFormUpdatesLastEventDateUtc { get; set; }

        public DateTimeOffset SntUpdatesLastEventDateUtc { get; set; }
        public long SntUpdatesLastSntId { get; set; }

        public bool BalancesFixApplied { get; set; }
    }
}
