using InventoryManagementSystem.Application.Common.Models;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Authentication.Register
{
    public record RegisterCommand(string FullName, string Email, string Password, string UserName) : IRequest< Result< bool>>;

}
