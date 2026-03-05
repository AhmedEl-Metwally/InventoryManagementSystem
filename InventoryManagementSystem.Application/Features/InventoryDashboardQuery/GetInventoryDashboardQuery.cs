using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Features.InventoryDashboardQuery
{
    public record GetInventoryDashboardQuery : IRequest<Result<InventoryDashboardDto>>, ICacheQuery
    {
        public string CacheKey => "Inventory_Dashboard_Data";

        public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }


}
