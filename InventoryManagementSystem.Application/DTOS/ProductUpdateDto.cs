namespace InventoryManagementSystem.Application.DTOS
{
    public record ProductUpdateDto
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int QuantityInStock { get; init; }
        public int CategoryId { get; init; }
        public int SupplierId { get; init; }
    }
}
