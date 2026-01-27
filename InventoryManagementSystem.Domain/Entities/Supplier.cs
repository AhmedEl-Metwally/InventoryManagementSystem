using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Supplier : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Product> Products { get; set; } = [];
    }
}