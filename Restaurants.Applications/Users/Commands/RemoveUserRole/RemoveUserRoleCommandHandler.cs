using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Restaurants.Applications.Users.Commands.RemoveUserRole
{
    public class RemoveUserRoleCommandHandler(
            ILogger logger,
            UserManager<Domain.Entities.User> userManager,
            RoleManager<IdentityRole> roleManager
        ) 
        
        : IRequestHandler<RemoveUserRoleCommand>
    {
        public async Task Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "Removing role {RoleName} from user {UserEmail}",
                request.RoleName,
                request.UserEmail
            );

            var user = await userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new Domain.Exceptions.NotFoundException(nameof(Domain.Entities.User), request.UserEmail);

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new Domain.Exceptions.NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}
