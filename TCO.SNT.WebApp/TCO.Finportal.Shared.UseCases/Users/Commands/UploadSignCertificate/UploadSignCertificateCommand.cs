using MediatR;
using TCO.Finportal.Shared.UseCases.Users.Shared;

namespace TCO.Finportal.Shared.UseCases.Users.Commands.UploadSignCertificate
{
    public class UploadSignCertificateCommand : IRequest<EsfUserProfileDto>
    {
        public UploadSignCertificateCommand(byte[] bytes, string password)
        {
            Bytes = bytes;
            Password = password;
        }

        public byte[] Bytes { get; }

        public string Password { get; }
    }
}
