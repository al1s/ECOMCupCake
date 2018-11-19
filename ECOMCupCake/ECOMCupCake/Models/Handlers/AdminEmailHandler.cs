using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Handlers
{
    public class AdminEmailHandler : AuthorizationHandler<RequireAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireAdminRequirement requirement)
        {
            if(!context.User.HasClaim(e => e.Type == ClaimTypes.Email))
            {
                return Task.CompletedTask;
            }
            string userEmail = context.User.FindFirst(claim => claim.Type == ClaimTypes.Email).Value;
            if(userEmail.Contains("@codefellows.com") ||
                userEmail.Contains("alstof@gmail.com") ||
                userEmail.Contains("guicansado@gmail.com"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
