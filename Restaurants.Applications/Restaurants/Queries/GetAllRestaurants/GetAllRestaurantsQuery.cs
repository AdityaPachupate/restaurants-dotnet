using MediatR;
using Restaurants.Applications.Restaurants.DTO;


namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
        public string? searchPhrase { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }   
    }
}
