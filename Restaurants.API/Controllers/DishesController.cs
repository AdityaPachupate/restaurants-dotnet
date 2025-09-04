using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Applications.Dishes.Commands.CreateDish;
using Restaurants.Applications.Dishes.Commands.DeleteAllDishForRestaurant;
using Restaurants.Applications.Dishes.DTO;
using Restaurants.Applications.Dishes.Queries.GetAllDishesForRestaurant;
using Restaurants.Applications.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Applications.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Applications.Dishes.Commands.DeleteDishByIdForRestaurant;
using Microsoft.AspNetCore.Authorization;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/[controller]")]
    [ApiController]
    //[Authorize]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute]int restaurantId , CreateDishCommand createDishCommand) 
        {
            createDishCommand.RestaurantId = restaurantId;
            var dishId = await mediator.Send(createDishCommand);
            return CreatedAtAction(nameof(GetDishByIdForRestaurant), new { restaurantId, DishId = dishId }, null);
        }

        [HttpGet]
        //[Authorize(Policy =PolicyNames.AtLeast20)]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{DishId}")]
        public async Task<ActionResult<DishDto>> GetDishByIdForRestaurant([FromRoute] int restaurantId , [FromRoute]int DishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, DishId));
            return Ok(dish);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllDishesForRestaurant([FromRoute] int restaurantId)
        {
            await mediator.Send(new DeleteAllDishForRestaurantCommand(restaurantId));
            return NoContent();
        }

        [HttpDelete("{DishId}")]
        public async Task<IActionResult> DeleteDishByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int DishId)
        {
            await mediator.Send(new DeleteDishByIdForRestaurantCommand(restaurantId, DishId));
            return NoContent();
        }
    }
}
