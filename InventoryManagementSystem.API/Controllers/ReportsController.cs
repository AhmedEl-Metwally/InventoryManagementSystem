using InventoryManagementSystem.Application.Features.InventoryDashboardQuery;
using InventoryManagementSystem.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    public class ReportsController(IMediator _mediator, IEmailService _emailService) : BaseController
    {
        [HttpGet("inventory-dashboard")]
        public async Task<IActionResult> GetInventoryDashboard()
        {
            var result = await _mediator.Send(new GetInventoryDashboardQuery());

            if (result.IsSuccess && result.Value.CurrentLowStockAlerts >= 1)
            {
                await _emailService.SendEmailAsync
                    (
                    "ahmed.moh.elmetwally@gmail.com",
                "Urgent: Low Stock Alert",
                   $"System Notification: There are currently {result.Value.CurrentLowStockAlerts} items below the minimum stock level. Please review the dashboard."
                    );
            }
            return HandleResult(result);
        }
    }
}
