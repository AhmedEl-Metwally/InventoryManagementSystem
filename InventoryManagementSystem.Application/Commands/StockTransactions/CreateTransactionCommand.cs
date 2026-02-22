using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.DTOS;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.StockTransactions
{
    public record CreateTransactionCommand(StockTransactionCreateDto TransactionCreateDto) : IRequest<Result<StockTransactionDetailsDto>>;

}
