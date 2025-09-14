using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.Common;
using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler
        (ILogger<GetAllRestaurantsQueryHandler> logger,IMapper mapper,IRestaurantsRepository restaurantsRepository)
        : IRequestHandler<GetAllRestaurantsQuery, PagedResults<RestaurantDto>>
    {
        public async Task<PagedResults<RestaurantDto>> Handle(GetAllRestaurantsQuery request, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation("Fetching all restaurants from the repository.");
            var (restaurants,totalCount) = await restaurantsRepository.GetAllMatchingRestaurantsAsync(request.searchPhrase,request.pageNumber,request.pageSize,request.SortBy,request.SortDirection);

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            var result = new PagedResults<RestaurantDto>(restaurantsDtos, totalCount, request.pageSize, request.pageNumber);
            

            return result;
        }
    }
}
 