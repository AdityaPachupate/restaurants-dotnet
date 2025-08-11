using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Domain.Repositories;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<RestaurantsDbContext>(options=>options
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
        
        );
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();
    }

}
