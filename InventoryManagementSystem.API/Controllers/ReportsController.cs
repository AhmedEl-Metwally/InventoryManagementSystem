using InventoryManagementSystem.Application.Features.InventoryDashboardQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    public class ReportsController(IMediator _mediator) : BaseController
    {
        [HttpGet("inventory-dashboard")]
        public async Task<IActionResult> GetInventoryDashboard()
        {
            var result = await _mediator.Send(new GetInventoryDashboardQuery());
            return HandleResult(result);
        }
    }
}
