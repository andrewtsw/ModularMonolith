using EsfApiSdk.Invoices;
using System;
using System.Threading.Tasks;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.SNT.EsfApi.Interfaces.Invoices
{
    public interface IEsfInvoiceService
    {
        Task<InvoiceUpdatesDto> GetAllUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, 
            long lastInvoiceId,
            InvoiceDirection direction, 
            bool fullInfoOnStatusChange);

        Task<InvoiceUpdatesDto> GetUpdatesAsync(EsfApiSessionId sessionId, DateTime lastEventDateUtc, 
            long lastInvoiceId,
            InvoiceDirection direction, 
            bool fullInfoOnStatusChange);

        Task<InvoiceInfo> GetInvoiceByIdAsync(EsfApiSessionId sessionId, long id);

        Task<InvoiceSummary> SetDeliveredStatusAsync(EsfApiSessionId sessionId, long id);
    }
}
