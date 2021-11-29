using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.UseCases.Users.Shared;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Shared.UseCases.Users.Queries.GetEsfUserProfile
{
    internal class GetEsfUserProfileQueryHandler : IRequestHandler<GetEsfUserProfileQuery, EsfUserProfileDto>
    {
        private readonly ISharedDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetEsfUserProfileQueryHandler(ISharedDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<EsfUserProfileDto> Handle(GetEsfUserProfileQuery request, CancellationToken cancellationToken)
        {
            var esfUserProfile = await _context.GetOrCreateEsfUserProfileAsync(_currentUserService.UserId, cancellationToken);
            return _mapper.Map<EsfUserProfileDto>(esfUserProfile);
        }
    }
}
