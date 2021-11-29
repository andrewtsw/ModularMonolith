using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.Contract;

namespace TCO.SNT.Functions.SharedServices
{
    public class ImportMeasureUnits
    {
        private readonly ISharedModuleContract _sharedModuleContract;

        public ImportMeasureUnits(ISharedModuleContract sharedModuleContract)
        {
            _sharedModuleContract = sharedModuleContract;
        }

        [FunctionName("ImportMeasureUnits")]
        public async Task Run([TimerTrigger("%TimerSchedules-ImportMeasureUnits%")] TimerInfo timer, ILogger logger, CancellationToken cancellationToken)
        {
             await _sharedModuleContract.ImportMeasureUnitsAsync(cancellationToken);
        }

    }
}
