using EsfApiSdk.UploadInvoice;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.SNT.EsfApi.Interfaces.UploadInvoice
{
    public interface IEsfUploadInvoiceService
    {
        Task<SyncInvoiceResponse> SyncInvoiceAsync(EsfApiSessionId sessionId, DigitalSignatureInfo signatureInfo);
    }
}
