using EsfApiSdk.Snt;
using System;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.SNT.EsfApi.Interfaces.Snt
{
    public interface IEsfSntService
    {
        Task<SntUpdatesDto> GetUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, long lastSntId);

        Task<UploadSntResponse> UploadSntAsync(EsfApiSessionId sessionId, DigitalSignatureInfo signatureInfo);

        Task<SntInfo> GetSntAsync(EsfApiSessionId sessionId, long sntId);

        Task<SntError> GetSntErrorsAsync(EsfApiSessionId sessionId, long sntId);

        Task<SntHistoryInfo> GetSntHistoryAsync(EsfApiSessionId sessionId, long sntId);

        Task<SntSummary> GetSntStatusAsync(EsfApiSessionId sessionId, long sntId);

        Task<SntChangeStatusResult> GetSntViewAsync(EsfApiSessionId sessionId, long sntId);

        Task<SntChangeStatusResult> ChangeStatusAsync(EsfApiSessionId sessionId, long sntId, DigitalSignatureInfo signatureInfo);
    }
}