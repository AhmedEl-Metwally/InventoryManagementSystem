using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Application.Commands.Authentication.RefreshToken
{
    public class RefreshTokenHandler(UserManager<ApplicationUser> _userManager, IJwtProvider _jwtProvider, IUserRepository _userRepository) : IRequestHandler<RefreshTokenCommand, Result<AuthResponseDto>>
    {
        public async Task<Result<AuthResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByRefreshTokenAsync(request.RefreshToken);
            if (user is null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return Result<AuthResponseDto>.Failure("Auth.InvalidToken", "Invalid or expired refresh token.", ErrorType.Unauthorized);
            var (token, expiresIn) = await _jwtProvider.GenerateToken(user);
            user.RefreshToken = _jwtProvider.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);
            var response = new AuthResponseDto(token, DateTime.UtcNow.AddMinutes(expiresIn), user.UserName!, user.RefreshToken);
            return Result<AuthResponseDto>.Success(response);

        }
    }
}
