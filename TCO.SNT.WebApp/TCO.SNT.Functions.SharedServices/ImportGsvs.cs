using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Products.Commands.ImportGsvs;

namespace TCO.SNT.Functions.SharedServices
{
    public class ImportGsvs
    {
        private readonly ISender _sender;

        public ImportGsvs(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportGsvs")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportGsvs%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportGsvsCommand(), cancellationToken);
        }
    }
}
