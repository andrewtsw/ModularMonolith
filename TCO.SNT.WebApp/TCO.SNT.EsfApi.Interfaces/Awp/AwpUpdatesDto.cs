using EsfApiSdk.Awp;
using System;
using System.Collections.Generic;

namespace TCO.SNT.EsfApi.Interfaces.Awp
{
    public class AwpUpdatesDto
    {
        public IReadOnlyList<AwpInfo> Updates { get; set; }

        public DateTime LastEventDateUtc { get; set; }

        public long LastAwpId { get; set; }
    }
}
