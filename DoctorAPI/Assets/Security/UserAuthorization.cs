using System.Security.Claims;
using DoctorAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace DoctorAPI.Assets.Security;

public class UserAuthorization : AuthorizationHandler<ValidUser>
{
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidUser requirement)
    {
       var timeStampClaim = context.User.FindFirst(claim => claim.Type == ("loginTimestamp"));

        if (timeStampClaim != null)
        {
            var tokenDate = Convert.ToDateTime(timeStampClaim.Value);
            var currentDate = DateTime.Now;
            var difference = tokenDate - currentDate;
            
            // Valida as 2h de duração do TOKEN
            if (difference.TotalHours > 0)
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}