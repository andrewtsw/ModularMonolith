using System.Threading;
using System.Threading.Tasks;
using VsSdk.VstoreSession;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreSessionService
    {
        Task<sessionStatus> CloseSessionByCredentialsAsync();
    }
}
