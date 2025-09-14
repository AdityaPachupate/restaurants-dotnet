using Restaurants.Domain.Entities;
using Restaurants.Domain.Constants;


namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
         Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<(IEnumerable<Restaurant>, int)> GetAllMatchingRestaurantsAsync(string? searchPhrase, int pageNumber, int pageSize, string? sortBy, SortDirection sortDirection);
         Task<Restaurant?> GetRestaurantByIdAsync(int id);
        Task<int> CreateRestaurant(Restaurant restaurant);
        
        Task DeleteRestaurant(Restaurant restaurant);
        Task SaveChanges();
    }
}
