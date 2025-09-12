using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Dishes.Commands.DeleteAllDishForRestaurant
{
    public class DeleteAllDishForRestaurantCommandHandler(
            ILogger<DeleteAllDishForRestaurantCommandHandler> logger,
            IDishesRepository dishesRepository,
            IRestaurantAuthorizationService restaurantAuthorizationService,
            IRestaurantsRepository restaurantsRepository
        ) 
        
        : IRequestHandler<DeleteAllDishForRestaurantCommand>
    {
        public async Task Handle(DeleteAllDishForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning("Deleting all dishes for restaurant: {RestaurantId}", request.RestaurantId);

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

            if (restaurant == null)
                throw new NotFoundException(nameof(restaurant), request.RestaurantId.ToString());

            if (restaurant.Dishes == null || !restaurant.Dishes.Any())
                throw new NotFoundException(nameof(restaurant.Dishes), request.RestaurantId.ToString());

            if (!restaurantAuthorizationService.Authorize(restaurant, Domain.Constants.ResourceOperation.Update))
            {
                throw new ForbiddenException();
            }

            await dishesRepository.DeleteAllDishAsync(restaurant.Dishes);

            logger.LogInformation("All dishes for restaurant {RestaurantId} have been deleted", request.RestaurantId);

        }
    }
}
