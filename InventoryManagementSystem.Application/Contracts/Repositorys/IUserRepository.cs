using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Contracts.Repositorys
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
