using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Applications.User;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Applications.Restaurants.Commands.CreateRestaurants;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> 
    logger,IMapper mapper, 
    IRestaurantsRepository restaurantsRepository,
    IUserContext context
    ) 
    : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser =  context.GetCurrentUser();
        logger.LogInformation("{UserEmail} [{UserId}] is creating a new restaurant {@Restaurant}" , currentUser.Email,currentUser.Id,request);

        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = currentUser.Id;
        int id = await restaurantsRepository.CreateRestaurant(restaurant);
        return id;
    }
}
