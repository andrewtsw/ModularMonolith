using System;
using System.Threading.Tasks;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.SNT.EsfApi.Interfaces.Awp
{
    public interface IEsfAwpService
    {
        Task<AwpUpdatesDto> GetUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastAwpId);

        Task<AwpUpdatesDto> GetAllUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastAwpId);
    }
}
