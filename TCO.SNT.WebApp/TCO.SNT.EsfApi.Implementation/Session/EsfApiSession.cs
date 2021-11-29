using EsfApiSdk.Session;
using System.Threading.Tasks;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.SNT.EsfApi.Implementation.Session
{
    internal class EsfApiSession : IEsfApiSession
    {
        private readonly EsfApiSessionService _esfApiSessionService;

        public EsfApiSession(EsfApiSessionService esfApiSessionService)
        {
            _esfApiSessionService = esfApiSessionService;
        }

        public EsfApiSessionId SessionId { get; private set; }

        public async Task CreateSessionAsync()
        {
            var sessionId = await _esfApiSessionService.CreateSessionAsync();
            SessionId = new EsfApiSessionId(sessionId);
        }

        public async Task<sessionStatus> GetCurrentStatusAsync()
        {
            return await _esfApiSessionService.CurrentSessionStatusAsync(SessionId);
        }

        public async ValueTask DisposeAsync()
        {
            if (SessionId != null)
            {
                await _esfApiSessionService.CloseSessionAsync(SessionId);
                SessionId = null;
            }
        }
    }
}
