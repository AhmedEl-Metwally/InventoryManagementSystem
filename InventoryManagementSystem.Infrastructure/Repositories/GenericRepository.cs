using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
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

        public async Task<IEnumerable<TEntity>> ListAsync(Ardalis.Specification.ISpecification<TEntity> specification) 
            => await ApplySpecification(specification).ToListAsync();

        // Helper method to apply specification
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification) 
            => SpecificationEvaluator.Default.GetQuery(_context.Set<TEntity>().AsQueryable(), specification);


    }
}
