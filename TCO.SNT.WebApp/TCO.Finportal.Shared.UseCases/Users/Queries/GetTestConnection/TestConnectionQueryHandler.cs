using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.VStore.Interfaces;

namespace TCO.Finportal.Shared.UseCases.Users.Queries.GetTestConnection
{
    internal class TestConnectionQueryHandler : IRequestHandler<TestConnectionQuery, TestConnectionResponseDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly ILogger _logger;

        public TestConnectionQueryHandler(ICurrentUserService currentUserService, IEsfApiSessionFactory esfApiSessionFactory, IVstoreSessionFactory vstoreSessionFactory, ILogger<TestConnectionQueryHandler> logger)
        {
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            _esfApiSessionFactory = esfApiSessionFactory ?? throw new ArgumentNullException(nameof(esfApiSessionFactory));
            _vstoreSessionFactory = vstoreSessionFactory ?? throw new ArgumentNullException(nameof(vstoreSessionFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TestConnectionResponseDto> Handle(TestConnectionQuery request, CancellationToken cancellationToken)
        {
            var response = new TestConnectionResponseDto() { IsSuccess = true };
            try
            {
                await using var esfApiSession = await _esfApiSessionFactory.CreateUserSessionAsync(_currentUserService.UserId, cancellationToken);
                await using var vstoreSession = await _vstoreSessionFactory.CreateUserSessionAsync(_currentUserService.UserId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to test ESF connection");
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
