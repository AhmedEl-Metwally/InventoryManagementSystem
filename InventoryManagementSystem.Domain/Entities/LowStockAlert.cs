using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class LowStockAlert : BaseEntity<int>
    {
        public int Threshold { get; set; }
        public bool AlertSent { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
