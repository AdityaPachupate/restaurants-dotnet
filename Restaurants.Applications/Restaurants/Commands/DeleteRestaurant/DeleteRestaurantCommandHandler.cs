using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Applications.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(
        ILogger<DeleteRestaurantCommandHandler> logger , IRestaurantsRepository restaurantsRepository)
        : IRequestHandler<DeleteRestaurantCommand,bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteRestaurantCommandHandler called with Id: {Id}", request.Id);

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);

            if (restaurant is null)
            {
                return false;
            }

           await restaurantsRepository.DeleteRestaurant(restaurant);
           return true;

        }
    }
}
