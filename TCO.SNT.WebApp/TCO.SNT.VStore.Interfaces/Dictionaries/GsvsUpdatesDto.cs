using System.Collections.Generic;
using VsSdk.Dictionaries;

namespace TCO.SNT.VStore.Interfaces
{
    public class GsvsUpdatesDto
    {
        public IReadOnlyList<GsvsUpdate> Updates { get; set; }

        public long LastChangeId { get; set; }
    }
}
