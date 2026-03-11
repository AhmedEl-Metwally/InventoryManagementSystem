using InventoryManagementSystem.Application.Features.InventoryDashboardQuery;
using InventoryManagementSystem.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ReportsController(IMediator _mediator, IEmailService _emailService) : BaseController
    {
        [HttpGet("inventory-dashboard")]
        public async Task<IActionResult> GetInventoryDashboard()
        {
            var result = await _mediator.Send(new GetInventoryDashboardQuery());
            if (result.IsSuccess)
                return Ok(new 
                {
                    TotalStockValue = result.Value.TotalInventoryValue,
                    TotalItemsInStock = result.Value.TotalStockQuantity,
                    TotalUniqueProducts = result.Value.TotalProducts,
                    GeneratedAt = DateTime.UtcNow
                });

            return HandleResult(result);
        }

        [HttpGet("sales-report")]
        public async Task<IActionResult> GetSalesReport()
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

            if (result.IsSuccess)
                return Ok(new 
                {
                    TotalRevenue = result.Value.TotalSalesRevenue,
                    TotalTransactions = result.Value.TotalSalesCount,
                    TopPerformingProducts = result.Value.TopSellingProducts,
                    GeneratedAt = DateTime.UtcNow
                });

            return HandleResult(result);
        }

        [HttpGet("dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            var result = await _mediator.Send(new GetInventoryDashboardQuery());
            return HandleResult(result);

        }
    }
}
