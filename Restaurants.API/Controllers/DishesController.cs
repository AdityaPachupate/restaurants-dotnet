using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Applications.Dishes.Commands;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/[controller]")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute]int restaurantId , CreateDishCommand createDishCommand) 
        {
            createDishCommand.RestaurantId = restaurantId;
            await mediator.Send(createDishCommand);
            return Created();
        }
    }
}
