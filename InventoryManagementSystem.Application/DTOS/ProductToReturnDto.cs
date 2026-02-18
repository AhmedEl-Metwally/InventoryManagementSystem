namespace InventoryManagementSystem.Application.DTOS
{
    public record ProductToReturnDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int QuantityInStock { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string SupplierName { get; init; } = string.Empty;
        public bool IsLowStock { get; init; }
    }

}


