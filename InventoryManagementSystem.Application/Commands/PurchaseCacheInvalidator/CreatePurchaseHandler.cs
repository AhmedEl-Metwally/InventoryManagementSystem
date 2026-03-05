using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.PurchaseCacheInvalidator
{
    public class CreatePurchaseHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreatePurchaseCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();
            var product = await productRepository.GetByIdAsync(request.ProductId);
            if (product is null)
                return Result<int>.Failure("ProductNotFound", $"Product with id {request.ProductId} not found.", ErrorType.NotFound);
            product.QuantityInStock += request.Quantity;

            var transaction = new Transaction
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Type = TransactionType.Purchase,
                Date = DateTime.UtcNow,
                TotalAmount = request.Quantity * request.PurchasePrice
            };

            var transactionRepository = _unitOfWork.GetRepository<Transaction, int>();
            await transactionRepository.AddAsync(transaction);
            productRepository.Update(product);

            var success = await _unitOfWork.SaveChangesAsync() > 0;
            return success ? Result<int>.Success(transaction.Id)
            : Result<int>.Failure("TransactionFailed", "Failed to create transaction.", ErrorType.Failure);
        }
    }
}
