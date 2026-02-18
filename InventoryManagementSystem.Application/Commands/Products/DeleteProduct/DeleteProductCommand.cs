using InventoryManagementSystem.Application.Common;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Products.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest<Result<bool>>;

}
