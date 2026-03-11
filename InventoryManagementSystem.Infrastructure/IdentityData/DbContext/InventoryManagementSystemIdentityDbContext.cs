using InventoryManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.IdentityData.DbContext
{
    public class InventoryManagementSystemIdentityDbContext(DbContextOptions<InventoryManagementSystemIdentityDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRoles, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationRoles>().ToTable("Roles");

        }
    }
}
