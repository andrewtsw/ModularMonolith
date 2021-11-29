using System.Collections.Generic;
using TCO.SNT.Common.Options;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Shared.UseCases.Users.Queries.GetUserProfile
{
    public class UserProfileDto
    {
        public IReadOnlyList<RoleType> Roles { get; set; }

        public CompanyOptions Company { get; set; }
    }
}
