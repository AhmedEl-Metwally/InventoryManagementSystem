using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Application.Commands.Authentication.Login
{
    public class LoginHandler(UserManager<ApplicationUser> _userManager, IJwtProvider _jwtProvider) : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
    {
        public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is null)
                return Result<AuthResponseDto>.Failure("Auth.InvalidCredentials", "Invalid username or password.", ErrorType.Unauthorized);


            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                return Result<AuthResponseDto>.Failure("Auth.InvalidCredentials", "Invalid username or password.", ErrorType.Unauthorized);


            var (token, expiresIn) = await _jwtProvider.GenerateToken(user);
            var refreshToken = _jwtProvider.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            var response = new AuthResponseDto(token, DateTime.UtcNow.AddMinutes(expiresIn), user.UserName!, refreshToken);

            return Result<AuthResponseDto>.Success(response);



        }
    }
}
