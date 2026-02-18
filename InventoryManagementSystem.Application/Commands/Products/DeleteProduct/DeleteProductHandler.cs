using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var repositoryOfProducts = _unitOfWork.GetRepository<Product, int>();
            var product = await repositoryOfProducts.GetByIdAsync(request.Id);
            if (product is null)
                return Result<bool>.Failure("Product.NotFound", "Product not found.", ErrorType.NotFound);
            repositoryOfProducts.Delete(product);
            var success = await _unitOfWork.SaveChangesAsync() > 0;
            return success ? Result<bool>.Success(true) : Result<bool>.Failure("Product.DeleteError", "Failed to delete the product.", ErrorType.Failure);
        }
    }
}
