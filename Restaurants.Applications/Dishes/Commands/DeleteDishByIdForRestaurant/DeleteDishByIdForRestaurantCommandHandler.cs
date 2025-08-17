using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Dishes.Commands.DeleteDishByIdForRestaurant
{
    public class DeleteDishByIdForRestaurantCommandHandler(
            ILogger<DeleteDishByIdForRestaurantCommandHandler> logger,
            IDishesRepository dishesRepository,
            IRestaurantsRepository restaurantsRepository

        ) : IRequestHandler<DeleteDishByIdForRestaurantCommand>
    {
        public async Task Handle(DeleteDishByIdForRestaurantCommand request, CancellationToken cancellationToken)
        {
           logger.LogInformation("Deleting Dish:{DishId} for restaurant:{restaurantId}", request.DishId, request.RestaurantId);

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

            if (restaurant == null)
                throw new NotFoundException(nameof(restaurant), request.RestaurantId.ToString());

            if (restaurant.Dishes == null || !restaurant.Dishes.Any())
                throw new NotFoundException(nameof(restaurant.Dishes), request.RestaurantId.ToString());

            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null)
                throw new NotFoundException("Dish", request.DishId.ToString());

            await dishesRepository.DeleteAllDishAsync(dish);

            logger.LogInformation("Deleted Dish:{DishId} for restaurant:{restaurantId}", request.DishId, request.RestaurantId);
        }
    }
}
