using MediatR;
using Restaurants.Applications.Common;
using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Constants;


namespace Restaurants.Applications.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<PagedResults<RestaurantDto>>
    {
        public string? searchPhrase { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }   

        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
