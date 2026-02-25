using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Specifications;
using Mapster;
using MediatR;

namespace InventoryManagementSystem.Application.Features.LowStockAlertsQuery
{
    public class GetLowStockAlertsHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetLowStockAlertsQuery, Result<IEnumerable<LowStockAlertDetailsDto>>>
    {
        public async Task<Result<IEnumerable<LowStockAlertDetailsDto>>> Handle(GetLowStockAlertsQuery request, CancellationToken cancellationToken)
        {
            var specification = new LowStockAlertWithProductSpecification();
            var alertRepository = _unitOfWork.GetRepository<LowStockAlert, int>();
            var alerts = await alertRepository.ListAsync(specification);
            var resultData = alerts.Adapt<IEnumerable<LowStockAlertDetailsDto>>();
            return Result<IEnumerable<LowStockAlertDetailsDto>>.Success(resultData);
        }
    }
}
