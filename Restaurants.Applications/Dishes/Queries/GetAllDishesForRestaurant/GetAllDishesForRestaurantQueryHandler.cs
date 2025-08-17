
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.Dishes.DTO;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Dishes.Queries.GetAllDishesForRestaurant
{
   

    public class GetAllDishesForRestaurantQueryHandler(
            ILogger<GetAllDishesForRestaurantQueryHandler> logger,
            IRestaurantsRepository restaurantsRepository,
            IMapper mapper
        )
        : IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetAllDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetAllDishesForRestaurantQuery for restaurant {RestaurantId}", request.RestaurantId);

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null )
                throw new NotFoundException(nameof(restaurant), request.RestaurantId.ToString());
            if (!(restaurant.Dishes?.Any() ?? false)) throw new NotFoundException(nameof(restaurant.Dishes) , request.RestaurantId.ToString());


            var result = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

            return result;
        }
    }
}
