using InventoryManagementSystem.Application.Common.Settings;
using InventoryManagementSystem.Infrastructure.Services;
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

            Services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            Services.AddTransient<IEmailService, EmailService>();

            return Services;
        }
    }
}
