using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task seed()
        {
            // Check if we are connected to dataBase
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var Restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(Restaurants);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }

            }

        }
        private IEnumerable<IdentityRole> GetRoles()
        {
           List<IdentityRole> roles = [
                new (UserRoles.Admin),
                new (UserRoles.User),
                new (UserRoles.Owner)
            ];
            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
                new()
                {
                    Name = "The Italian Bistro",
                    Category = "Italian",
                    Description = "A cozy Italian restaurant offering authentic pasta and pizza.",
                    ContactEmail = "info@italianbistro.com",
                    ContactNumber = "+1-212-555-1234",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "New York",
                        Street = "123 Main St",
                        PostalCode = "10001",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Spaghetti Carbonara",
                            Description = "Classic Roman pasta with eggs, cheese, pancetta, and pepper.",
                            Price = 15.99M
                        },
                        new Dish
                        {
                            Name = "Margherita Pizza",
                            Description = "Traditional pizza with tomato, mozzarella, and basil.",
                            Price = 12.50M
                        }
                    }
                },
                new()
                {
                    Name = "Sushi World",
                    Category = "Japanese",
                    Description = "Fresh sushi and sashimi prepared by expert chefs.",
                    ContactEmail = "contact@sushiworld.com",
                    ContactNumber = "+1-646-555-5678",
                    HasDelivery = false,
                    Address = new Address()
                    {
                        City = "San Francisco",
                        Street = "456 Market St",
                        PostalCode = "94111",
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Salmon Nigiri",
                            Description = "Fresh salmon over seasoned rice.",
                            Price = 4.00M
                        },
                        new Dish
                        {
                            Name = "California Roll",
                            Description = "Crab, avocado, and cucumber roll.",
                            Price = 8.50M
                        }
                    }
                }
            ];

            return restaurants;
        }
    }
}
