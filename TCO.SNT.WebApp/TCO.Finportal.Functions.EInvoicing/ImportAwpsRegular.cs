using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsRegular;

namespace TCO.Finportal.Functions.EInvoicing
{
    public class ImportAwpsRegular
    {
        private readonly ISender _sender;

        public ImportAwpsRegular(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportAwpsRegular")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportAwpsRegular%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportAwpsRegularCommand(), cancellationToken);
        }
    }
}
