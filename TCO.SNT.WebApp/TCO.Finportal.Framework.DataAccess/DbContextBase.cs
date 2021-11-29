using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Framework.DataAccess
{
    public abstract class DbContextBase<TContext> : DbContext
        where TContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public DbContextBase(DbContextOptions<TContext> options, ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
