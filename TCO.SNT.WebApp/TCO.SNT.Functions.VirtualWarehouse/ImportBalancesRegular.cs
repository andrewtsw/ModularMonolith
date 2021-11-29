using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Balances.Commands.ImportBalancesRegular;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class ImportBalancesRegular
    {
        private readonly ISender _sender;

        public ImportBalancesRegular(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportBalancesRegular")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportBalances%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportBalancesRegularCommand { ProcessUndistributedStore = true }, cancellationToken);
        }
    }
}
