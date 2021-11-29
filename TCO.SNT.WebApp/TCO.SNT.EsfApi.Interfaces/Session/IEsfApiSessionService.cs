using EsfApiSdk.Session;
using System.Threading.Tasks;

namespace TCO.SNT.EsfApi.Interfaces.Session
{
    public interface IEsfApiSessionService
    {
        Task<sessionStatus> CloseSessionByCredentialsAsync();
    }
}
