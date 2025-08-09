namespace Restaurants.Applications.Restaurants.Commands.UpdateRestaurant
{
    using AutoMapper;
    using global::Restaurants.Domain.Repositories;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class UpdateRestaurantCommandHandler(
        ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantRepository,
        IMapper mapper
        )
        : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating restaurant with Id: {Id}", request.Id);
            var restaurant = await restaurantRepository.GetRestaurantByIdAsync(request.Id);
            if (restaurant is null)
            {
                logger.LogWarning("Restaurant with Id: {Id} not found", request.Id);
                return false;
            }

            // Update restaurant properties
            mapper.Map(request, restaurant);
            

            // Save changes to the repository
            await restaurantRepository.SaveChanges();
            logger.LogInformation("Restaurant with Id: {Id} updated successfully", request.Id);
            return true;
        }
    }
}
