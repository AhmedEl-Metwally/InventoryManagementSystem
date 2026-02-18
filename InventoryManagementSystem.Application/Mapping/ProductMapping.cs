using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using Mapster;
using System.Reflection;

namespace InventoryManagementSystem.Application.Mapping
{
    public static class ProductMapping
    {
        public static void ProductsMapping()
        {
            TypeAdapterConfig<Product, ProductToReturnDto>
                .NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name)
                .Map(dest => dest.SupplierName, src => src.Supplier.Name)
                .Map(dest => dest.IsLowStock, src => src.QuantityInStock < 10);

            TypeAdapterConfig<ProductCreateDto, Product>.NewConfig();
            TypeAdapterConfig<ProductUpdateDto, Product>.NewConfig();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
