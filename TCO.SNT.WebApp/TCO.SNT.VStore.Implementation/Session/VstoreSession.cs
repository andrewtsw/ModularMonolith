using System.Threading.Tasks;
using TCO.SNT.VStore.Interfaces;
using VsSdk.VstoreSession;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreSession : IVstoreSession
    {
        private readonly VstoreSessionService _vstoreSessionService;

        public VstoreSession(VstoreSessionService vstoreSessionService)
        {
            _vstoreSessionService = vstoreSessionService;
        }

        public VstoreSessionId SessionId { get; private set; }

        public async Task CreateSessionAsync()
        {
            var sessionId = await _vstoreSessionService.CreateSessionAsync();
            SessionId = new VstoreSessionId(sessionId);
        }

        public async Task<sessionStatus> GetCurrentStatusAsync()
        {
            return await _vstoreSessionService.CurrentSessionStatusAsync(SessionId);
        }

        public async ValueTask DisposeAsync()
        {
            if (SessionId != null)
            {
                await _vstoreSessionService.CloseSessionAsync(SessionId);
                SessionId = null;
            }
        }
    }
}
