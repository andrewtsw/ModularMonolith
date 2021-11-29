using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Currency.Commands.ImportExchangeRates;

namespace TCO.SNT.Functions.SharedServices
{
    public class ImportExchangeRates
    {
        private readonly ISender _sender;

        public ImportExchangeRates(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportExchangeRates")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportExchangeRates%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportExchangeRatesCommand(), cancellationToken);
        }
    }
}
