using System;
using System.Threading.Tasks;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreDictionariesService
    {
        Task<MeasureUnitUpdatesDto> GetMeasureUnitUpdatesAsync(VstoreSessionId sessionId, DateTime lastUpdateDateUtc);

        Task<GsvsUpdatesDto> GetGsvsUpdates(VstoreSessionId sessionId, long lastChangeId);
    }
}
