using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.CreateProduct
{
    public record CreateProductCommand(ProductCreateDto ProductCreateDto) : IRequest<Result<ProductToReturnDto>>;

}
