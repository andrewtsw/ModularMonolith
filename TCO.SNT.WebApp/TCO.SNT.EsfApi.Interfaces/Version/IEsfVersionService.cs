using EsfApiSdk.Version;
using System.Threading.Tasks;

namespace TCO.SNT.EsfApi.Interfaces
{
    public interface IEsfVersionService
    {
        Task<string> GetApiVersionAsync();

        Task<errorDescription[]> GetErrorCodesAsync(Language language);

        Task<string> GetEsfVersionAsync();

        Task<string> GetVersionAsync();
    }
}