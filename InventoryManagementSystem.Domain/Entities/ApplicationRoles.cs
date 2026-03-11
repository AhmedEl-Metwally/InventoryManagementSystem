using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Domain.Entities
{
    public class ApplicationRoles : IdentityRole
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Staff = "Staff";
    }
}
