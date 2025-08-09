using MediatR;
using Restaurants.Applications.Restaurants.DTO;


namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {

    }
}
