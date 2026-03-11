namespace InventoryManagementSystem.Application.DTOS
{
    public record ProductPerformanceDto
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public int TotalSoldQuantity { get; init; }
        public decimal TotalRevenue { get; init; }
    }
}
