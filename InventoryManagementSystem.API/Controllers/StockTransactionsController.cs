using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Application.Features.LowStockAlertsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    public class StockTransactionsController(IMediator _mediator) : BaseController
    {
        [HttpGet("low-stock-alerts")]
        [ProducesResponseType(typeof(Result<IEnumerable<LowStockAlertDetailsDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetLowStockAlerts() => HandleResult(await _mediator.Send(new GetLowStockAlertsQuery()));
    }
}
