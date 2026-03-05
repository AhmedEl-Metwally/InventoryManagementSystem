using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.SaleCacheInvalidator
{
    public class CreateSaleHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateSaleCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();
            var product = await productRepository.GetByIdAsync(request.ProductId);
            if (product is null)
                return Result<int>.Failure("ProductNotFound", $"Product with id {request.ProductId} not found.", ErrorType.NotFound);
            if (product.QuantityInStock < request.Quantity)
                return Result<int>.Failure("InsufficientStock", $"Not enough stock for product id {request.ProductId}. Available: {product.QuantityInStock}, Requested: {request.Quantity}.", ErrorType.ValidationError);
            product.QuantityInStock -= request.Quantity;

            var transaction = new Transaction
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Type = TransactionType.Sale,
                Date = DateTime.UtcNow,
                TotalAmount = request.Quantity * product.Price,
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
