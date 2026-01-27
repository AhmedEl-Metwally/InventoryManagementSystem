using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infrastructure.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(T => T.Quantity).IsRequired();
            builder.Property(T => T.Date).IsRequired();
            builder.Property(T => T.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasKey(T => T.Id);
            builder.HasOne(T => T.Product).WithMany().HasForeignKey(T => T.ProductId);
        }
    }
}
