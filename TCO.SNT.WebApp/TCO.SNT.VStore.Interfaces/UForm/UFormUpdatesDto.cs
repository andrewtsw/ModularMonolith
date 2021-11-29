using System;
using System.Collections.Generic;
using VsSdk.UForm;

namespace TCO.SNT.VStore.Interfaces
{
    public class UFormUpdatesDto
    {
        public IReadOnlyList<UFormInfo> Updates { get; set; }

        public DateTime LastEventDateUtc { get; set; }
    }
}
