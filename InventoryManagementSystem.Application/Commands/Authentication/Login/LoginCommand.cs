using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Authentication.Login
{
    public record LoginCommand(string UserName, string Password) : IRequest<Result< AuthResponseDto>>;
   
}
