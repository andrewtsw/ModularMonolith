using System;
using System.Collections.Generic;
using VsSdk.VstoreBalance;

namespace TCO.SNT.VStore.Interfaces
{
    public class BalanceUpdatesDto
    {
        public IReadOnlyList<BalanceUpdate> Updates { get; set; }

        public DateTime LastEventDateUtc { get; set; }

        public long LastBalanceId { get; set; }
    }
}
