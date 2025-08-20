namespace Restaurants.Infrastructure.Authorization
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using System.Security.Claims;

    public class RestaurantsUserClaimPrincipalFactory(
        UserManager<Domain.Entities.User> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> options
    )
        : UserClaimsPrincipalFactory<Domain.Entities.User, IdentityRole>(userManager, roleManager, options)
    {
        // Custom implementation can be added here if needed

        public override async Task<ClaimsPrincipal> CreateAsync(Domain.Entities.User user)
        {
            var id = await GenerateClaimsAsync(user);

            if(user.Nationality != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
            }

            if (user.DateOfBirth != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            return new ClaimsPrincipal(id);
        }
    }
    
}
