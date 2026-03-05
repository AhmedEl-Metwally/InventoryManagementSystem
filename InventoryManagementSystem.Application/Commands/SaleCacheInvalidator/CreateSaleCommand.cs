using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Models;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.SaleCacheInvalidator
{
    public record CreateSaleCommand : IRequest<Result<int>>, ICacheInvalidatorCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string[] CacheKey => ["Inventory_Dashboard_Data", "All_Transactions_List"];
    }
}
