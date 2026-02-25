using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using Mapster;

namespace InventoryManagementSystem.Application.Mapping
{
    public static class LowStockAlertMapping
    {
        public static void LowStockAlertsMapping()
        {
            TypeAdapterConfig<LowStockAlert, LowStockAlertDetailsDto>
                .NewConfig()
                .Map(dest => dest.ProductName, src => src.Product.Name)
                .Map(dest => dest.Date, src => src.Date.ToString("yyyy-MM-dd HH:mm"))
                .Map(dest => dest.CurrentQuantity, src => src.Product.QuantityInStock);
        }
    }
}
