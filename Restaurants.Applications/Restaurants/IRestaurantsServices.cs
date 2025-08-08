using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Entities;

namespace Restaurants.Applications.Restaurants
{
    public interface IRestaurantsServices
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync();
        Task<RestaurantDto?> GetRestaurantById(int id);
        Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
    }
}



