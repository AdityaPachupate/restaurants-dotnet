using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.Dishes.DTO;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Dishes.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(
            ILogger<GetDishByIdForRestaurantQueryHandler> logger,
            IRestaurantsRepository restaurantsRepository,
            IMapper mapper
        ) 
        : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Fetching Dish:{DishId} for restaurant:{restaurantId}", request.DishId, request.RestaurantId);

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

            if (restaurant == null)
                throw new NotFoundException(nameof(restaurant),request.RestaurantId.ToString());

            var Dish = restaurant.Dishes.FirstOrDefault(dish => dish.Id == request.DishId);

            if (Dish == null)
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());

            var dishDto = mapper.Map<DishDto>(Dish);
            return dishDto;

        }
    }
}
