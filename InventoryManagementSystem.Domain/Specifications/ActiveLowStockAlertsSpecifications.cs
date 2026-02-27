using Ardalis.Specification;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Specifications
{
    public class ActiveLowStockAlertsSpecifications : Specification<LowStockAlert>
    {
        public ActiveLowStockAlertsSpecifications()
        {
            Query.Where(A => !A.AlertSent);
        }
    }
}
