using System.Collections.Generic;
using System.Threading.Tasks;
using VsSdk.TaxpayerStore;

namespace TCO.SNT.VStore.Interfaces
{
    public interface ITaxpayerStoreService
    {
        Task<IReadOnlyList<TaxpayerStore>> GetAllAsync(VstoreSessionId sessionId);
    }
}
