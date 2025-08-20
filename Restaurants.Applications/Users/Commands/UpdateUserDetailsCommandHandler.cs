namespace Restaurants.Applications.User.Commands
{
    using global::Restaurants.Domain.Exceptions;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserDetailsCommandHandler(
            ILogger<UpdateUserDetailsCommandHandler> logger,
            IUserContext userContext,
            IUserStore<Domain.Entities.User> userStore
        ) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
           
            logger.LogInformation("Updating user details for user {UserId} with {@Request}", user!.Id, request);

            var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken);

            if (dbUser == null)
                throw new NotFoundException(nameof(User),user!.Id);

            dbUser.Natinality = request.Natinality;
            dbUser.DateOfBirth = request.DateOfBirth;

            await userStore.UpdateAsync(dbUser, cancellationToken);



        }
    }
}
