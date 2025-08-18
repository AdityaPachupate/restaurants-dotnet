using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Applications.Restaurants;
using Restaurants.Applications.User;
//using Restaurants.Applications.Restaurants.Validators;


namespace Restaurants.Applications.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;
            services.AddAutoMapper(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(applicationAssembly));
            services.AddScoped<IUserContext, User.UserContext>();
            services.AddHttpContextAccessor();

        }
    }
}
