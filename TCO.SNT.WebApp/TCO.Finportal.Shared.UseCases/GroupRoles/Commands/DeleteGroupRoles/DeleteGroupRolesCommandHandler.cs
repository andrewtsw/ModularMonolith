using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.SNT.Common.Extensions;

namespace TCO.Finportal.Shared.UseCases.GroupRoles.Commands.DeleteGroupRoles
{
    internal class DeleteGroupRolesCommandHandler : AsyncRequestHandler<DeleteGroupRolesCommand>
    {
        private readonly ISharedDbContext _context;

        public DeleteGroupRolesCommandHandler(ISharedDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteGroupRolesCommand request, CancellationToken cancellationToken)
        {
            var rolesToDelete = await _context.GroupRoles
                        .Where(q => q.GroupId == request.GroupId)
                        .ToListAsync(cancellationToken);

            if (!rolesToDelete.IsNullOrEmpty())
            {
                _context.GroupRoles.RemoveRange(rolesToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
