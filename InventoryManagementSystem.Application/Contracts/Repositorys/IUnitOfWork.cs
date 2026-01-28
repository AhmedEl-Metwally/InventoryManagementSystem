using InventoryManagementSystem.Domain.Common;

namespace InventoryManagementSystem.Application.Contracts.Repositorys
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>;
    }
}
