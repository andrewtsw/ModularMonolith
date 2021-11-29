using MediatR;
using TCO.Finportal.Shared.UseCases.Users.Shared;

namespace TCO.Finportal.Shared.UseCases.Users.Queries.GetEsfUserProfile
{
    public class GetEsfUserProfileQuery : IRequest<EsfUserProfileDto>
    {
    }
}
