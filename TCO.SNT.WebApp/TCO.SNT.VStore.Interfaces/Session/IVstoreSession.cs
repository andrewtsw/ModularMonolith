using System;
using System.Threading.Tasks;
using VsSdk.VstoreSession;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreSession : IAsyncDisposable
    {
        VstoreSessionId SessionId { get; }

        Task<sessionStatus> GetCurrentStatusAsync();
    }
}