using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        //[ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = default!;

    }
}
