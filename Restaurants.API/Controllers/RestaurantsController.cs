namespace Restaurants.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Restaurants.Applications.Restaurants.Commands.CreateRestaurants;
    using Restaurants.Applications.Restaurants.Commands.DeleteRestaurant;
    using Restaurants.Applications.Restaurants.Commands.UpdateRestaurant;
    using Restaurants.Applications.Restaurants.Queries.GetAllRestaurants;
    using Restaurants.Applications.Restaurants.Queries.GetRestaurantById;

    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantsById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            int id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetRestaurantsById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));
            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
        {
            updateRestaurantCommand.Id = id; // Set the Id for the command
            await mediator.Send(updateRestaurantCommand);
            return NotFound();
        }
    }
}