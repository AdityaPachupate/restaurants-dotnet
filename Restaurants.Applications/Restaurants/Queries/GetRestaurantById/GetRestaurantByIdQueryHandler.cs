using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler
        (ILogger<GetRestaurantByIdQueryHandler> logger,
         IMapper mapper,
         IRestaurantsRepository restaurantsRepository)
        : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Fetching restaurant with ID: {Id}", request.Id);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
            if (restaurant == null) throw new NotFoundException($"Restaurant with Id {request.Id} not found.");
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
    }
}
