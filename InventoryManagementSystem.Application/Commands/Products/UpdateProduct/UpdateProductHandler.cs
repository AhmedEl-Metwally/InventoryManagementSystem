using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateProductCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var repositoryOfProducts = _unitOfWork.GetRepository<Product, int>();
            var product = await repositoryOfProducts.GetByIdAsync(request.Id);
            if (product is null)
                return Result<bool>.Failure("Product.NotFound", "Product not found.", ErrorType.NotFound);
            _mapper.Map(request.ProductUpdateDto, product);
            repositoryOfProducts.Update(product);
            var success = await _unitOfWork.SaveChangesAsync() > 0;
            return success ? Result<bool>.Success(true) : Result<bool>.Failure("Product.UpdateError", "Failed to update product.", ErrorType.Failure);
        }
    }
}
