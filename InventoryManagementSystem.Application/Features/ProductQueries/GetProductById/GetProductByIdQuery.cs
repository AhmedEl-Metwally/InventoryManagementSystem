using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Features.ProductQueries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<Result<ProductToReturnDto>>;

}
