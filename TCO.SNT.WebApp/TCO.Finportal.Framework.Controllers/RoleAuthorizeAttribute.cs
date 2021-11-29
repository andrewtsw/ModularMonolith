using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Roles;

namespace TCO.Finportal.Framework.Controllers
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public RoleType[] RoleTypes { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rolesService = (ISharedModuleContract)context.HttpContext.RequestServices.GetService(typeof(ISharedModuleContract));
            if (!rolesService.IsCurrentUserHasAnyRole(RoleTypes))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
