using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Invoices.Commands.ImportInvoicesRegular;

namespace TCO.Finportal.Functions.EInvoicing
{
    public class ImportInvoicesRegular
    {
        private readonly ISender _sender;

        public ImportInvoicesRegular(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportInvoicesRegular")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportInvoicesRegular%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportInvoicesRegularCommand(), cancellationToken);
        }
    }
}
