using AutoMapper;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.KeyVault.Interfaces;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.Entities.Exceptions;
using TCO.Finportal.Shared.UseCases.Users.Shared;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Shared.UseCases.Users.Commands.UploadAuthCertificate
{
    internal class UploadAuthCertificateCommandHandler : IRequestHandler<UploadAuthCertificateCommand, EsfUserProfileDto>
    {
        private readonly ISharedDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IKeyVaultService _keyVaultService;

        public UploadAuthCertificateCommandHandler(ISharedDbContext context, IMapper mapper,
            ICurrentUserService currentUserService,
            IKeyVaultService keyVaultService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _keyVaultService = keyVaultService;
        }

        public async Task<EsfUserProfileDto> Handle(UploadAuthCertificateCommand request, CancellationToken cancellationToken)
        {
            (byte[] exportedData, _) = ThrowIfCertitificateInvalid(request);

            var base64ExportedData = Convert.ToBase64String(exportedData);

            var secretName = $"esf-base64-auth-cert-{_currentUserService.UserId}";
            await _keyVaultService.SetSecretAsync(secretName, base64ExportedData, cancellationToken);

            var esfUserProfile = await _context.GetOrCreateEsfUserProfileAsync(_currentUserService.UserId, cancellationToken);

            esfUserProfile.Base64AuthCertificateSecretName = secretName;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EsfUserProfileDto>(esfUserProfile);
        }

        private (byte[], X509Certificate2) ThrowIfCertitificateInvalid(UploadAuthCertificateCommand request)
        {
            try
            {
                var certificate = new X509Certificate2(request.Bytes, request.Password,
                X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                return (certificate.Export(X509ContentType.Cert), certificate);

            }
            catch (CryptographicException)
            {
                throw new InvalidCertificateException();
            }
        }
    }
}
