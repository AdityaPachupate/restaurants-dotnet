using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler
        (ILogger<GetAllRestaurantsQueryHandler> logger,IMapper mapper,IRestaurantsRepository restaurantsRepository)
        : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation("Fetching all restaurants from the repository.");
            var restaurants = await restaurantsRepository.GetAllMatchingRestaurantsAsync(request.searchPhrase,request.pageNumber,request.pageSize);
            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }
    }
}
 