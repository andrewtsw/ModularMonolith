using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Balances.Commands.FixBalancesImportKey;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class FixBalancesImportKey
    {
        private readonly ISender _sender;

        public FixBalancesImportKey(ISender sender)
        {
            _sender = sender;
        }

        [FunctionName("FixBalancesImportKey")]
        [Disable]
        public async Task Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest request, ILogger logger, CancellationToken cancellationToken)
        {
            await _sender.Send(new FixBalancesImportKeyCommand(), cancellationToken);
        }
    }
}
