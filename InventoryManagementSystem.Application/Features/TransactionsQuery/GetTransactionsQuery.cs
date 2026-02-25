using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Features.TransactionsQuery
{
    public record GetTransactionsQuery : IRequest<Result<IEnumerable<StockTransactionDetailsDto>>>;

}
