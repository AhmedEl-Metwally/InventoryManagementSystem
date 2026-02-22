namespace InventoryManagementSystem.Application.DTOS
{
    public record StockTransactionDetailsDto
    {
        public int Id { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public int QuantityInStock { get; set; }
        public string Type { get; init; } = string.Empty;
        public DateTime Date { get; init; } = DateTime.UtcNow;
        public decimal TotalAmount { get; init; }


    }
}
