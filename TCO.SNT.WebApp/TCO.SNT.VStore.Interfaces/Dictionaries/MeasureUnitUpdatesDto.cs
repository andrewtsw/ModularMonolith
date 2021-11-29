using System;
using System.Collections.Generic;
using VsSdk.Dictionaries;

namespace TCO.SNT.VStore.Interfaces
{
    public class MeasureUnitUpdatesDto
    {
        public IReadOnlyList<MeasureUnit> Updates { get; set; }

        public DateTime? LastUpdateDateUtc { get; set; }
    }
}
