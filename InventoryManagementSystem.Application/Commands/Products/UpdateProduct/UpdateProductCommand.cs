using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Products.UpdateProduct
{
    public record UpdateProductCommand(int Id, ProductUpdateDto ProductUpdateDto) : IRequest<Result<bool>>;

}
