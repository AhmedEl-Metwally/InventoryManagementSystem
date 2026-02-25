using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Features.ProductQueries.GetAllProducts
{
    public record GetProductsQuery(int? CategoryId, string? Search) : IRequest<Result<IEnumerable<ProductToReturnDto>>>;

}
