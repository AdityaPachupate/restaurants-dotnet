using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Authorization.Requirements
{
    public class MinimumAgeRequirementsHandler(
            ILogger<MinimumAgeRequirements> logger,
            IUserContext userContext
        ) : AuthorizationHandler<MinimumAgeRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirements requirement)
        {
            var currentUser = userContext.GetCurrentUser();
            
            logger.LogInformation("User : {Email}, DateOfBirth: {DateOfBirth} - Handling MinimumAgeRequirement", currentUser?.Email, currentUser?.DateOfBirth);

            if(currentUser.DateOfBirth == null)
            {
                logger.LogInformation("User: {Email} does not have a DateOfBirth set", currentUser?.Email);
                return Task.CompletedTask;
            }

            if (currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.UtcNow))
            {
                logger.LogInformation("User: {Email} meets the minimum age requirement of {MinimumAge}", currentUser?.Email, requirement.MinimumAge);
                context.Succeed(requirement);
            }
            else
            {
                logger.LogInformation("User: {Email} does not meet the minimum age requirement of {MinimumAge}", currentUser?.Email, requirement.MinimumAge);
                context.Fail();

            }
            return Task.CompletedTask;
        }
    }
}
