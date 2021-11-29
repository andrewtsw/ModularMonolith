using System;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using VsSdk.UForm;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreUFormService
    {
        Task<uploadUFormResponse1> UploadUFormAsync(VstoreSessionId sessionId, DigitalSignatureInfo signatureInfo);

        Task<UFormUpdatesDto> GetUpdatesAsync(VstoreSessionId sessionId, DateTime lastEventDateUtc);

        Task<UFormInfo> GetUFormAsync(VstoreSessionId sessionId, long id);

        Task<UFormErrorInfo> GetUFormErrorsAsync(VstoreSessionId sessionId, long id);

        Task<UFormSummary> GetUFormStatusAsync(VstoreSessionId sessionId, long id);
    }
}
