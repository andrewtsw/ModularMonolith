using Chevron.Identity;
using Chevron.Identity.AspNet.Client;
using System;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.WebApp.Services
{
    public class CurrentUserService : ICurrentUserService, ICurrentUserNameableService
    {
        //To use CvxClaimsPrincipal we need to inject ICvxClaimsPrincipal (https://dev.azure.com/chevron/CVX-Nuget/_wiki/wikis/CAL%20Wiki/22850/Dependency-Injected-Services-and-Middleware)
        public CurrentUserService(/*ICvxClaimsPrincipal _*/)
        {
        }

        public Guid UserId => Guid.Parse("6136d35a-066c-4166-866c-9912f658688b"); //Guid.Parse(CvxClaimsPrincipal.Current.ObjectId);

        public string Name => "";

        public bool IsInGroup(Guid id) => true; //CvxClaimsPrincipal.Current.IsInRole(id.ToString());
    }
}
