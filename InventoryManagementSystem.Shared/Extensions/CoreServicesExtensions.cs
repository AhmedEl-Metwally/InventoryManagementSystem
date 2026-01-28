using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementSystem.Shared.Extensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services)
        {
            Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            return Services;
        }
    }
}
