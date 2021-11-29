using EsfApiSdk.Snt;
using System;
using System.Collections.Generic;

namespace TCO.SNT.EsfApi.Interfaces.Snt
{
    public class SntUpdatesDto
    {
        public IReadOnlyList<SntInfo> Updates { get; set; }

        public DateTime LastEventDateUtc { get; set; }

        public long LastSntId { get; set; }
    }
}
