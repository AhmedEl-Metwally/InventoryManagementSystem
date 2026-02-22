using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using Mapster;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.StockTransactions
{
    public class CreateTransactionHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateTransactionCommand, Result<StockTransactionDetailsDto>>
    {
        public async Task<Result<StockTransactionDetailsDto>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();
            var product = await productRepository.GetByIdAsync(request.TransactionCreateDto.ProductId);
            if (product == null)
                return Result<StockTransactionDetailsDto>.Failure("ProductNotFound", $"Product with ID {request.TransactionCreateDto.ProductId} not found.", ErrorType.NotFound);
            if (request.TransactionCreateDto.Type == TransactionType.Sale)
            {
                if (product.QuantityInStock < request.TransactionCreateDto.Quantity)
                    return Result<StockTransactionDetailsDto>.Failure("InsufficientStock", $"Not enough stock for product ID {request.TransactionCreateDto.ProductId}.", ErrorType.ValidationError);
                product.QuantityInStock -= request.TransactionCreateDto.Quantity;
            }
            else
                product.QuantityInStock += request.TransactionCreateDto.Quantity;

            var transaction = request.TransactionCreateDto.Adapt<Transaction>();
            transaction.TotalAmount = product.Price * request.TransactionCreateDto.Quantity;
            await _unitOfWork.GetRepository<Transaction, int>().AddAsync(transaction);
            productRepository.Update(product);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            return result ?
                Result<StockTransactionDetailsDto>.Success(transaction.Adapt<StockTransactionDetailsDto>()) :
                Result<StockTransactionDetailsDto>.Failure("TransactionFailed", "Failed to create transaction.", ErrorType.ValidationError);
        }
    }
}
