using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Snt.Commands.SendSntReport;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class SendSntReport
    {
        private readonly ISender _sender;
        private readonly SntReportOptions _reportOptions;

        public SendSntReport(ISender sender, IOptions<SntReportOptions> reportOptions)
        {
            _sender = sender;
            _reportOptions = reportOptions.Value;
        }

        [FunctionName("SendSntReport")]
        public async Task Run([TimerTrigger("%TimerSchedules-SendSntReport%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new SendSntReportCommand(new SntListFilter(), _reportOptions.AzureFunctionBasePath), cancellationToken);
        }
    }
}
