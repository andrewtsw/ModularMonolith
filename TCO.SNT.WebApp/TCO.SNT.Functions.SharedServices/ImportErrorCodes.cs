using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.ErrorCode.Commands.ImportErrorCodes;

namespace TCO.SNT.Functions.SharedServices
{
    public class ImportErrorCodes
    {
        private readonly ISender _sender;

        public ImportErrorCodes(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportErrorCodes")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportErrorCodes%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportErrorCodesCommand(), cancellationToken);
        }

    }
}
