using Ardalis.Specification;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Specifications
{
    public class ProductWithDetailsSpecification : Specification<Product>
    {
        public ProductWithDetailsSpecification(int id)
        {
            Query.Where(P => P.Id == id)
                 .Include(P => P.Category)
                 .Include(P => P.Supplier);
        }
    }
}
