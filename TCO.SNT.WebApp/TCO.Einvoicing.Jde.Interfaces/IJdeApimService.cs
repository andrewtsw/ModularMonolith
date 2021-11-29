using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.Einvoicing.Jde.Interfaces.Models;

namespace TCO.Einvoicing.Jde.Interfaces
{
    public interface IJdeApimService
    {
        Task<AccountReceivablesDto> GetJdeArInvoicesAsync(DateTimeOffset dateUpdated, string nextPageToken, CancellationToken cancellationToken);
    }
}