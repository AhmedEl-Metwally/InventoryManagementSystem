using FluentValidation;
using InventoryManagementSystem.Application.Behaviors;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.Mapping;
using InventoryManagementSystem.Infrastructure.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace InventoryManagementSystem.Shared.Extensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services, Assembly assembly)
        {
            Services.AddMediatR(CFG =>
            {
                CFG.RegisterServicesFromAssembly(assembly);
                CFG.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });
            Services.AddValidatorsFromAssembly(assembly);

            ProductMapping.ProductsMapping();
            var categoryMapping = TypeAdapterConfig.GlobalSettings;
            Services.AddSingleton(categoryMapping);
            Services.AddScoped<IMapper, ServiceMapper>();

            Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            return Services;
        }
    }
}
