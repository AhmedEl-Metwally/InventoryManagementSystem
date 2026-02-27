using Ardalis.Specification;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Specifications
{
    public class SalesTransactionsSpecification : Specification<Transaction>
    {
        public SalesTransactionsSpecification()
        {
            Query.Where(T => T.Type == TransactionType.Sale);
        }
    }
}
