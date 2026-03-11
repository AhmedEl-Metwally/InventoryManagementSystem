using InventoryManagementSystem.Application.Commands.Authentication.Login;
using InventoryManagementSystem.Application.Commands.Authentication.RefreshToken;
using InventoryManagementSystem.Application.Commands.Authentication.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController(IMediator _mediator) : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
            => HandleResult(await _mediator.Send(loginCommand));

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
             => HandleResult(await _mediator.Send(registerCommand));

        [HttpPost("Refresh-Token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand refreshTokenCommand)
            => HandleResult(await _mediator.Send(refreshTokenCommand));
    }
}
