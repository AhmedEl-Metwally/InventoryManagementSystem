using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Infrastructure.Data.Context;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork(InventoryManagementSystemDbContext _context) : IUnitOfWork,IAsyncDisposable
    {
        private readonly Dictionary<Type, object> _repositories = [];

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
        {
            var EntityType = typeof(TEntity);
            if (_repositories.TryGetValue(EntityType, out object? repository))
                return (IGenericRepository<TEntity, TKey>)repository;
            var newRepository = new GenericRepository<TEntity, TKey>(_context);
            _repositories[EntityType] = newRepository;
            return newRepository;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
