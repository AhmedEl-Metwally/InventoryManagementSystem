using Ardalis.Specification;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Specifications
{
    public class LowStockProductsSpecification : Specification<Product>
    {
        public LowStockProductsSpecification(int threshold = 5)
        {
            Query.Where(P => P.QuantityInStock <= threshold)
                 .OrderBy(P => P.QuantityInStock);
        }
    }
}
