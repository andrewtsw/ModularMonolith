using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsInitial;

namespace TCO.Finportal.Functions.EInvoicing
{
    public class ImportAwpsInitial
    {
        private readonly ISender _sender;

        public ImportAwpsInitial(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportAwpsInitial")]
        [Disable]
        public async Task Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportAwpsInitialCommand(), cancellationToken);
        }
    }
}
