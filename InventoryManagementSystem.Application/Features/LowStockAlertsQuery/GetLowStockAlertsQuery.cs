using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Features.LowStockAlertsQuery
{
    public record GetLowStockAlertsQuery : IRequest<Result<IEnumerable<LowStockAlertDetailsDto>>>;
}
