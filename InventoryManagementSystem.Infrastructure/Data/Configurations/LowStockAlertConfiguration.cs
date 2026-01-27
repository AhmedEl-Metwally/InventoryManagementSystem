using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infrastructure.Data.Configurations
{
    public class LowStockAlertConfiguration : IEntityTypeConfiguration<LowStockAlert>
    {
        public void Configure(EntityTypeBuilder<LowStockAlert> builder)
        {
            builder.Property(L => L.Threshold).IsRequired();
            builder.Property(L => L.AlertSent).IsRequired().HasDefaultValue(false);
            builder.Property(L => L.Date).IsRequired();

            builder.HasKey(L => L.Id);
            builder.HasOne(L => L.Product).WithMany().HasForeignKey(L => L.ProductId);
        }
    }
}
