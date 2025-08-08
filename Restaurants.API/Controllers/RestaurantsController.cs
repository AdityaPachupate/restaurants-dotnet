using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Applications.Restaurants;
using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Entities;
using System.Threading.Tasks;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController(IRestaurantsServices restaurantService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantsById([FromRoute] int id)
        {
            var restaurant = await restaurantService.GetRestaurantById(id);
            if (restaurant is null) return NotFound();
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            int id = await restaurantService.CreateRestaurant(createRestaurantDto);
            return CreatedAtAction(nameof(GetRestaurantsById),new {id},null);
        }
    }
}
