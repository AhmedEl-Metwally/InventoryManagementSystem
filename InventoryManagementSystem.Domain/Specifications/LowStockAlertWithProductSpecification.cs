using Ardalis.Specification;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Specifications
{
    public class LowStockAlertWithProductSpecification : Specification<LowStockAlert>
    {
        public LowStockAlertWithProductSpecification()
        {
            Query.Include(L => L.Product)
                 .OrderByDescending(L => L.Date);
        }
    }
}
