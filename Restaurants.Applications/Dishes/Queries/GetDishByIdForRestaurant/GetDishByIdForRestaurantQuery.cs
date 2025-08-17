using MediatR;
using Restaurants.Applications.Dishes.DTO;
using Restaurants.Domain.Entities;

namespace Restaurants.Applications.Dishes.Queries.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQuery(int RestaurantId , int DishId) : IRequest<DishDto>
    {
        public int RestaurantId { get; } = RestaurantId;
        public int DishId { get; } = DishId;
    }
}
