using InventoryManagementSystem.Application.Commands.CreateProduct;
using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace InventoryManagementSystem.Application.Commands.Products.CreateProduct
{
    public class CreateProductHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateProductCommand, Result<ProductToReturnDto>>
    {
        public async Task<Result<ProductToReturnDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductCreateDto);
            await _unitOfWork.GetRepository<Product, int>().AddAsync(product);
            var success = await _unitOfWork.SaveChangesAsync() > 0;
            if (!success)
                return Result<ProductToReturnDto>.Failure("Product.CreateError", "Failed to create product.", ErrorType.Failure);
            var resultDto = _mapper.Map<ProductToReturnDto>(product);
            return Result<ProductToReturnDto>.Success(resultDto);
        }
    }
}

