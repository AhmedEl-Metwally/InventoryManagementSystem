using MediatR;

namespace InventoryManagementSystem.Application.Common.Events
{
    public record ProductLowStockEvent(int ProductId, int CurrentQuantity, int Threshold) : INotification;
}
