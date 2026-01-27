using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).HasMaxLength(500);
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)");

            builder.HasKey(P => P.Id);
            builder.HasOne(P => P.Supplier).WithMany(P => P.Products).HasForeignKey(P => P.SupplierId);
            builder.HasOne(P => P.Category).WithMany().HasForeignKey(P => P.CategoryId);
        }
    }
}
