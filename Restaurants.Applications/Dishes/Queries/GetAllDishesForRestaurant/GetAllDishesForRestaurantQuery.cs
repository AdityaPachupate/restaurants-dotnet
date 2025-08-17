using MediatR;
using Restaurants.Applications.Dishes.DTO;

namespace Restaurants.Applications.Dishes.Queries.GetAllDishesForRestaurant
{
    public class GetAllDishesForRestaurantQuery(int restaurantId) : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; } = restaurantId;
    }
    
}
