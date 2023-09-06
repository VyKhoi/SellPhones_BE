using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SellPhones.Data.Interfaces;
using System.Security.Claims;

namespace SellPhones.Security.Authorization
{
    public class RolesInDBAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public RolesInDBAuthorizationHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
    RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity!.IsAuthenticated)
            {
                context.Fail();
                return;
            }
            var t = context.User.FindFirstValue(ClaimTypes.Role);
            var found = false;
            if (requirement.AllowedRoles == null || requirement.AllowedRoles.Any() == false)
            {
                found = true;
            }
            else
            {
                var userId = context.User.FindFirstValue(ClaimTypes.Name);
                var roles = requirement.AllowedRoles.FirstOrDefault();
                var roleId = UnitOfWork.RoleRepository.GetAll().Where(x => x.Name == roles).Select(x => x.Id).FirstOrDefault();
                found = await UnitOfWork.UserRoleRepository.GetAll().AnyAsync(x => x.UserId.ToString() == userId && x.RoleId == roleId);
            }

            if (found)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}