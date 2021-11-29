using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.KeyVault.Interfaces;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.UseCases.Users.Shared;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Shared.UseCases.Users.Commands.SetPassword
{
    internal class SetPasswordCommandHandler : IRequestHandler<SetPasswordCommand, EsfUserProfileDto>
    {
        private readonly ISharedDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IKeyVaultService _keyVaultService;

        public SetPasswordCommandHandler(ISharedDbContext context, IMapper mapper,
            ICurrentUserService currentUserService,
            IKeyVaultService keyVaultService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _keyVaultService = keyVaultService;
        }

        public async Task<EsfUserProfileDto> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            var secretName = $"esf-password-{_currentUserService.UserId}";
            await _keyVaultService.EncryptSecretAsync(secretName, request.Password, cancellationToken);

            var esfUserProfile = await _context.GetOrCreateEsfUserProfileAsync(_currentUserService.UserId, cancellationToken);

            esfUserProfile.PasswordSecretName = secretName;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EsfUserProfileDto>(esfUserProfile);
        }
    }
}
