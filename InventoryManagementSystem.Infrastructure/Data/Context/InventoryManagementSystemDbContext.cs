using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Data.Context
{
    public class InventoryManagementSystemDbContext(DbContextOptions<InventoryManagementSystemDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryManagementSystemDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Product>()
                .Where(E => E.State == EntityState.Added || E.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                if(entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LowStockAlert> LowStockAlerts { get; set; }
    }
}
