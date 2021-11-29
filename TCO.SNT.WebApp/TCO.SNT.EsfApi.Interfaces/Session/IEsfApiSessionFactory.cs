using System;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.SNT.EsfApi.Interfaces.Session
{
    public interface IEsfApiSessionFactory
    {
        Task<IEsfApiSession> CreateSessionAsync(CancellationToken cancellationToken);

        Task<IEsfApiSessionService> CreateSessionServiceAsync(CancellationToken cancellationToken);

        Task<IEsfApiSession> CreateUserSessionAsync(Guid? userId, CancellationToken cancellationToken);

        Task<IEsfApiSessionService> CreateUserSessionServiceAsync(Guid? userId, CancellationToken cancellationToken);
    }
}