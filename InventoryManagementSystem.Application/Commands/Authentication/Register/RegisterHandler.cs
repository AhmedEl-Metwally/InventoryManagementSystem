using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Application.Commands.Authentication.Register
{
    public class RegisterHandler(UserManager<ApplicationUser> _userManager) : IRequestHandler<RegisterCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var firstError = result.Errors.FirstOrDefault();
                return Result<bool>.Failure( firstError.Code, firstError.Description, ErrorType.ValidationError);
            }

            await _userManager.AddToRoleAsync(user, ApplicationRoles.Staff);

            return Result<bool>.Success(true);
        }
    }
}
