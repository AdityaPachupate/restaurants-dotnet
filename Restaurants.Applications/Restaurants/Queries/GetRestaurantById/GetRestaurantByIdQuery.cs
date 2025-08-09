using MediatR;
using Restaurants.Applications.Restaurants.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Applications.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery(int Id) : IRequest<RestaurantDto?>
    {
        public int Id { get;} = Id;
    }
}
