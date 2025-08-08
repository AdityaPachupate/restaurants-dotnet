using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.Restaurants.DTO;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Restaurants
{
    internal class RestaurantsServices(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsServices> logger, IMapper mapper) : IRestaurantsServices
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync()
        {
            logger.LogInformation("Fetching all restaurants from the repository.");
            var restaurants = await restaurantsRepository.GetAllRestaurantsAsync();
            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        public async Task<RestaurantDto?> GetRestaurantById(int id)
        {
            logger.LogInformation("Fetching restaurant with ID: {Id}", id);
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
            return restaurantDto;
        }

        public async Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            logger.LogInformation("Creating restaurant");
            var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
            int id = await restaurantsRepository.CreateRestaurant(restaurant);
            return id;
        }
    }


}
