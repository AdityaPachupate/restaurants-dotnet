using MediatR;

namespace Restaurants.Applications.Dishes.Commands.DeleteAllDishForRestaurant
{
    public class DeleteAllDishForRestaurantCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get; } = restaurantId;
    }
    
}
