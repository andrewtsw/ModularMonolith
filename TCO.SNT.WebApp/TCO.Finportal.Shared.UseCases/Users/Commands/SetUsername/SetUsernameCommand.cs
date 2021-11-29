using MediatR;
using TCO.Finportal.Shared.UseCases.Users.Shared;

namespace TCO.Finportal.Shared.UseCases.Users.Commands.SetUsername
{
    public class SetUsernameCommand : IRequest<EsfUserProfileDto>
    {
        public SetUsernameCommand(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
