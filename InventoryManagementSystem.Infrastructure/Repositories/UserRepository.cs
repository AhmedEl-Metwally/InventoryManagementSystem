using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.IdentityData.DbContext;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infrastructure.Repositories
{
    public class UserRepository(InventoryManagementSystemIdentityDbContext _context) : IUserRepository
    {
        public async Task<ApplicationUser?> GetUserByRefreshTokenAsync(string refreshToken)
            => await _context.Users.FirstOrDefaultAsync(U =>U.RefreshToken == refreshToken);
       
    }
}
