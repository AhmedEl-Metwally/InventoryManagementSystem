using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using Mapster;

namespace InventoryManagementSystem.Application.Mapping
{
    public static class StockTransactionMapping
    {
        public static void StockTransactionsMapping()
        {
            TypeAdapterConfig<Transaction, StockTransactionDetailsDto>
                .NewConfig()
                .Map(dest => dest.ProductName, src => src.Product.Name)
                .Map(dest => dest.QuantityInStock, src => src.Quantity)
                .Map(dest => dest.Type, src => src.Type.ToString());

            TypeAdapterConfig<StockTransactionDetailsDto, Transaction>.NewConfig();
        }
    }
}




