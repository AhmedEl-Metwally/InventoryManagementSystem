using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementSystem.Shared.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices<TContext>(this IServiceCollection Services, IConfiguration Configuration) where TContext : DbContext
        {
            Services.AddDbContext<TContext>(Option => 
            {
                Option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            return Services;
        }
    }
}
