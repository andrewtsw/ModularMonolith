using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Invoices.Commands.ImportJdeArInvoices;

namespace TCO.Finportal.Functions.EInvoicing
{
    public class ImportJdeArInvoices
    {
        private readonly ISender _sender;

        public ImportJdeArInvoices(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportJdeArInvoices")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportJdeArInvoices%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportJdeArInvoicesCommand(), cancellationToken);
        }
    }
}
