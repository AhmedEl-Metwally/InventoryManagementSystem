using InventoryManagementSystem.Application.Commands.PurchaseCacheInvalidator;
using InventoryManagementSystem.Application.Commands.SaleCacheInvalidator;
using InventoryManagementSystem.Application.Features.InventoryDashboardQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin,Manager,Staff")]
    public class InventoryController(IMediator _mediator) : BaseController
    {
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var result = await _mediator.Send(new GetInventoryDashboardQuery());
            return HandleResult(result);
        }

        [HttpPost("sale")]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand createSaleCommand)
            => HandleResult(await _mediator.Send(createSaleCommand));

        [HttpPost("purchase")]
        public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseCommand createPurchaseCommand)
            => HandleResult(await _mediator.Send(createPurchaseCommand));
    }
}
