using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using Mapster;
using MediatR;

namespace InventoryManagementSystem.Application.Features.TransactionsQuery
{
    public class GetTransactionsHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetTransactionsQuery, Result<IEnumerable<StockTransactionDetailsDto>>>
    {
        public async Task<Result<IEnumerable<StockTransactionDetailsDto>>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactionRepository = _unitOfWork.GetRepository<Transaction, int>();
            var transactions = await transactionRepository.GetAllAsync();
            if (transactions == null || !transactions.Any())
                return Result<IEnumerable<StockTransactionDetailsDto>>.Success(Enumerable.Empty<StockTransactionDetailsDto>());
            var transactionDto = transactions.Adapt<IEnumerable<StockTransactionDetailsDto>>();
            return Result<IEnumerable<StockTransactionDetailsDto>>.Success(transactionDto);
        }
    }
}
