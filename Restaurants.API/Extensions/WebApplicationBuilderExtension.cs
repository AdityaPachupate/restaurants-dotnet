namespace Restaurants.API.Extensions
{
    using Microsoft.OpenApi.Models;
    using Restaurants.API.Middlewares;
    using Restaurants.Applications.Extensions;
    using Restaurants.Infrastructure.Extensions;
    using Serilog;
    using Serilog.Formatting.Compact;

    public static class WebApplicationBuilderExtension
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(conf =>
            {
                conf.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                }
                );

                conf.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            []
        }
    });
            });

            new CompactJsonFormatter();

            builder.Services.AddInfrastucture(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

            builder.Host.UseSerilog((Context, configuration) => configuration.ReadFrom.Configuration(Context.Configuration));
        }
    }
}
