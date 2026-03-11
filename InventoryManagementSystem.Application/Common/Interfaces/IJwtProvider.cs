using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        Task<(string Token, int ExpiresIn)> GenerateToken(ApplicationUser user);
        string GenerateRefreshToken();
    }
}
