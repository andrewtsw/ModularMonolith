using MediatR;
using TCO.Finportal.Shared.UseCases.Users.Shared;

namespace TCO.Finportal.Shared.UseCases.Users.Commands.UploadAuthCertificate
{
    public class UploadAuthCertificateCommand : IRequest<EsfUserProfileDto>
    {
        public UploadAuthCertificateCommand(byte[] bytes, string password)
        {
            Bytes = bytes;
            Password = password;
        }
        
        public byte[] Bytes { get; }

        public string Password { get; }
    }
}
