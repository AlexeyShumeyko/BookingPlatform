using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookingPlatform.Application.Auth
{
    public class AdminRequirement : IAuthorizationRequirement { }

    public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin"))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
