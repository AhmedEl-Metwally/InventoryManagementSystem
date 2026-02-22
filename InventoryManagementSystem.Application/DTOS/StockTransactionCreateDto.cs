using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.DTOS
{
    public record StockTransactionCreateDto
    {
        public int ProductId { get; init; }
        public int Quantity { get; init; }
        public TransactionType Type { get; init; }

    }
}
