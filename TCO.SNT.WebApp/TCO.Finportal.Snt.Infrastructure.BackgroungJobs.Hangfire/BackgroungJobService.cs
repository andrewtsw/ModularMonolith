using Hangfire;
using MediatR;
using System.Threading;
using TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Balances.Commands.ImportBalancesRegular;

namespace TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Hangfire
{
    internal class BackgroungJobService : IBackgroungJobService
    {
        private readonly ISender _sender;
        private readonly IBackgroundJobClient _backgroungJobClient;
        private readonly ICurrentUserService _currentUserService;

        public BackgroungJobService(ISender sender,
            IBackgroundJobClient backgroungJobClient,
            ICurrentUserService currentUserService)
        {
            _sender = sender;
            _backgroungJobClient = backgroungJobClient;
            _currentUserService = currentUserService;
        }

        public void EnqueueImportBalances()
        {
            var command = new ImportBalancesRegularCommand 
            { 
                UserId = _currentUserService.UserId,
                ProcessUndistributedStore = false
            };
            _backgroungJobClient.Enqueue(() => _sender.Send(command, CancellationToken.None));
        }
    }
}
