using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VsSdk.VstoreBalance;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreBalanceService
    {
        Task<IReadOnlyList<Balance>> GetCurrentStatusAsync(VstoreSessionId sessionId);
    }
}
