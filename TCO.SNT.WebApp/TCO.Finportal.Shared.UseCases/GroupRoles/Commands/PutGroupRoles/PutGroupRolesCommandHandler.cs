using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.Entities;
using TCO.SNT.Common.Extensions;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Commands.PutGroupRoles
{
    internal class PutGroupRolesCommandHandler : AsyncRequestHandler<PutGroupRolesCommand>
    {
        private readonly ISharedDbContext _context;

        public PutGroupRolesCommandHandler(ISharedDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(PutGroupRolesCommand request, CancellationToken cancellationToken)
        {
            var oldRoles = await _context.GroupRoles
                .Where(q => q.GroupId == request.GroupId)
                .ToListAsync(cancellationToken);

            if (!oldRoles.IsNullOrEmpty())
            {
                _context.GroupRoles.RemoveRange(oldRoles);
            }

            var newRoles = request.Roles.Select(q => new GroupRole
            {
                GroupId = request.GroupId,
                Role = q,
            });

            _context.GroupRoles.AddRange(newRoles);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
