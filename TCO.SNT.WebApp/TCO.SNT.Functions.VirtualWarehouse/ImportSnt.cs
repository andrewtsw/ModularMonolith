using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Snt.Commands.Import;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class ImportSnt
    {
        private readonly ISender _sender;

        public ImportSnt(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportSnt")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportSnt%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportSntCommand(), cancellationToken);
        }
    }
}
