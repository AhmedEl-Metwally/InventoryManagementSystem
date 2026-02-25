namespace InventoryManagementSystem.Application.DTOS
{
    public record LowStockAlertDetailsDto
    {
        public int Id { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public int CurrentQuantity { get; init; }
        public int Threshold { get; init; }
        public DateTime Date { get; init; } = DateTime.UtcNow;

    }
}
