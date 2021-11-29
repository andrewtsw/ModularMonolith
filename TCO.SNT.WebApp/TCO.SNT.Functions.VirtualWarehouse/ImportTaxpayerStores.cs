using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.TaxpayerStores.Commands.ImportTaxpayerStores;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class ImportTaxpayerStores
    {
        private readonly ISender _sender;

        public ImportTaxpayerStores(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportTaxpayerStores")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportTaxpayerStores%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportTaxpayerStoresCommand(), cancellationToken);
        }
    }
}
