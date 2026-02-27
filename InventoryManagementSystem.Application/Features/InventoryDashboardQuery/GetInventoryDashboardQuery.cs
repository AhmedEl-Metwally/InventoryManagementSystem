using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Features.InventoryDashboardQuery
{
    public record GetInventoryDashboardQuery : IRequest<Result<InventoryDashboardDto>>;

}
