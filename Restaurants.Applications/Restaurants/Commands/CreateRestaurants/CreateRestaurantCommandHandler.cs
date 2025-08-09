using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Restaurants.Commands.CreateRestaurants;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> 
    logger,IMapper mapper, IRestaurantsRepository restaurantsRepository) 
    : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating restaurant");
        var restaurant = mapper.Map<Restaurant>(request);
        int id = await restaurantsRepository.CreateRestaurant(restaurant);
        return id;
    }
}
