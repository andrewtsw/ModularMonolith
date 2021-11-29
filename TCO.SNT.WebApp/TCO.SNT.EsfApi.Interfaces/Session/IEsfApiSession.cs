using EsfApiSdk.Session;
using System;
using System.Threading.Tasks;

namespace TCO.SNT.EsfApi.Interfaces.Session
{
    public interface IEsfApiSession : IAsyncDisposable
    {
        EsfApiSessionId SessionId { get; }

        Task<sessionStatus> GetCurrentStatusAsync();
    }
}