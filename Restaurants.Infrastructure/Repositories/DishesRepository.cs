using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
    {
        public async Task<int> CreateDishAsync(Dish dishEntity)
        {
            dbContext.Dishes.Add(dishEntity);
            await dbContext.SaveChangesAsync();
            return dishEntity.Id;
        }
    }
}
