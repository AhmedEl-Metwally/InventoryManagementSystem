using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey>(InventoryManagementSystemDbContext _context)
        : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TKey id) => await _context.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

    }
}
