using Ardalis.Specification;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Specifications
{
    public class ProductFilterSpecification : Specification<Product>
    {
        public ProductFilterSpecification(int? categoryId, string? search)
        {
            if (categoryId.HasValue)
                Query.Where(P => P.CategoryId ==categoryId);

            if (!string.IsNullOrEmpty(search))
                Query.Where(P => P.Name.Contains(search));

            Query.OrderBy(P => P.Name);
        }
    }
}
