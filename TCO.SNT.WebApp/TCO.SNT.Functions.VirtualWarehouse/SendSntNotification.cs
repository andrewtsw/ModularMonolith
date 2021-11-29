using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Snt.Commands.SendSntNotification;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class SendSntNotification
    {
        private readonly ISender _sender;

        public SendSntNotification(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("SendSntNotification")]
        public async Task Run([TimerTrigger("%TimerSchedules-SendSntNotification%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new SendSntNotificationCommand(), cancellationToken);
        }
    }
}
