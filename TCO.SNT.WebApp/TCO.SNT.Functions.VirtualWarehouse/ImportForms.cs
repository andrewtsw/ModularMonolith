using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.UForms.Commands.ImportUForms;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class ImportForms
    {
        private readonly ISender _sender;

        public ImportForms(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportForms")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportForms%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportUFormsCommand(), cancellationToken);
        }
    }
}
