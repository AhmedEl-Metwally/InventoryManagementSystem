using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace InventoryManagementSystem.Shared.Extensions
{
    public static class OpenApiExtensions
    {
        public static IServiceCollection AddSharedOpenApiDocumentation(this IServiceCollection services)
        {
            services.AddOpenApi();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IMS Inventory Management API",
                    Version = "v1",
                    Description = "Clean Architecture Inventory System - Development Phase"
                });
            });

            return services;

        }
    }
}
