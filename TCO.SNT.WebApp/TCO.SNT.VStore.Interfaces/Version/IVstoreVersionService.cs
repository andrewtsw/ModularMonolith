using System.Threading.Tasks;
using VsSdk.Version;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreVersionService
    {
        Task<errorDescription[]> GetErrorCodesAsync(Language language);

        Task<string> GetVersionAsync();

        Task<string> GetApiVersionAsync();

        Task<string> GetUFormVersionAsync();
    }
}
