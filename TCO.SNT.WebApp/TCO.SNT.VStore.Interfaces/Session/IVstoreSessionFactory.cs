using System;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.SNT.VStore.Interfaces
{
    public interface IVstoreSessionFactory
    {
        Task<IVstoreSession> CreateSessionAsync(CancellationToken cancellationToken);

        Task<IVstoreSessionService> CreateSessionServiceAsync(CancellationToken cancellationToken);

        Task<IVstoreSession> CreateUserSessionAsync(Guid? userId, CancellationToken cancellationToken);

        Task<IVstoreSessionService> CreateUserSessionServiceAsync(Guid? userId, CancellationToken cancellationToken);
    }
}
