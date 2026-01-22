using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace InventoryManagementSystem.Shared.Extensions
{
    public static class WebApplicationMiddlewareExtensions
    {
        public static WebApplication UseSharedOpenApiDocumentation(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint("/openapi/v1.json", "API v1");
                    option.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
