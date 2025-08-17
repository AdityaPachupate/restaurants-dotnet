using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IDishesRepository
    {
        Task<int> CreateDishAsync(Dish dishEntity);
        Task<List<Dish>> GetAllDishesForRestaurantAsync(int restaurantId);
        Task DeleteDishAsync(Dish dish);
        Task DeleteAllDishAsync(IEnumerable<Dish> dishes);
    }
}
