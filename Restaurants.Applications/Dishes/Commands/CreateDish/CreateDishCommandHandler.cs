namespace Restaurants.Applications.Dishes.Commands.CreateDish
{
    using AutoMapper;
    using global::Restaurants.Domain.Entities;
    using global::Restaurants.Domain.Exceptions;
    using global::Restaurants.Domain.Repositories;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class CreateDishCommandHandler(
        ILogger<CreateDishCommandHandler> logger,
        IRestaurantsRepository restaurantRepository,
        IDishesRepository dishesRepository,
        IMapper mapper
        ) : IRequestHandler<CreateDishCommand , int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish : {@Dish}", request);

            var restaurant = await restaurantRepository.GetRestaurantByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(restaurant), request.RestaurantId.ToString());

            var dish = mapper.Map<Dish>(request);

            return await dishesRepository.CreateDishAsync(dish);
           


        }
    }
}
