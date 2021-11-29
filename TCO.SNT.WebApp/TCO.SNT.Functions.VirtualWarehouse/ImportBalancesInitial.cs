using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Balances.Commands.ImportBalancesInitial;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class ImportBalancesInitial
    {
        private readonly ISender _sender;

        public ImportBalancesInitial(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("ImportBalancesInitial")]
        [Disable]
        public async Task Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new ImportBalancesInitialCommand(), cancellationToken);
        }
    }
}
