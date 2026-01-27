using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infrastructure.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(S => S.Name).IsRequired().HasMaxLength(100);
            builder.Property(S => S.CompanyName).HasMaxLength(150);
            builder.Property(S => S.PhoneNumber).HasMaxLength(20);

            builder.ToTable("Suppliers", S =>
              S.HasCheckConstraint("CK_Supplier_Phone_Egypt", "[PhoneNumber] LIKE '01[0125]%' AND LEN([PhoneNumber]) = 11"));

            builder.HasKey(S => S.Id);
            builder.HasMany(S => S.Products).WithOne(P => P.Supplier).HasForeignKey(P => P.SupplierId);
        }
    }
}
