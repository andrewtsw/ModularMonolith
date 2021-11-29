using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Shared.ApplicationServices;
using TCO.SNT.Common.Options;

namespace TCO.Finportal.Shared.UseCases.Users.Queries.GetUserProfile
{
    internal class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
    {
        private readonly CompanyOptions _companyOptions;
        private readonly RolesService _rolesService;

        public GetUserProfileQueryHandler(IOptions<CompanyOptions> companyOptions,
            RolesService rolesService)
        {
            _companyOptions = companyOptions.Value;
            _rolesService = rolesService;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            return new UserProfileDto
            {
                Roles = await _rolesService.GetUserRoles(cancellationToken),
                Company = _companyOptions
            };
        }
    }
}
