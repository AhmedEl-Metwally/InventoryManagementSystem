using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Transaction : BaseEntity<int>
    {
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }

        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
