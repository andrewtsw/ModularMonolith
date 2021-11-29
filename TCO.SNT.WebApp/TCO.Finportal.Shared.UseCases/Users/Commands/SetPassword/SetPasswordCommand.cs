using MediatR;
using TCO.Finportal.Shared.UseCases.Users.Shared;

namespace TCO.Finportal.Shared.UseCases.Users.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest<EsfUserProfileDto>
    {
        public SetPasswordCommand(string password)
        {
            Password = password;
        }

        public string Password { get; }
    }
}
