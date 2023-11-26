using System;
using System.Security.Claims;
using AstroScreen_Cinema.Models;
using Microsoft.AspNetCore.Authorization;

namespace AstroScreen_Cinema.AuthorizationAuthentication
{
    public class DataDisplayRequirementHandler : AuthorizationHandler<DataDisplayRequirement, Account>
    {
        public DataDisplayRequirementHandler()
        {
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            DataDisplayRequirement requirement, Account resource)
        {
            if (requirement.ResourceOperation == ResourceOperation.MyAccount ||
                requirement.ResourceOperation == ResourceOperation.Reservation)
            {
                context.Succeed(requirement);
            }

            var userId = int.Parse(context.User.FindFirst(c => c.Type ==
            ClaimTypes.NameIdentifier).Value);

            if (userId.Equals(resource.Account_ID))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}