using InventoryManagementSystem.Application.Common.Events;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.StockTransactions
{
    public class LowStockAlertHandler(IUnitOfWork _unitOfWork) : INotificationHandler<ProductLowStockEvent>
    {
        public async Task Handle(ProductLowStockEvent notification, CancellationToken cancellationToken)
        {
            var alertRepository = _unitOfWork.GetRepository<LowStockAlert,int>();
            var alert = new LowStockAlert 
            {
                ProductId = notification.ProductId,
                Threshold = notification.Threshold,
                Date = DateTime.UtcNow,
                AlertSent = false,
            };
            await alertRepository.AddAsync(alert);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
