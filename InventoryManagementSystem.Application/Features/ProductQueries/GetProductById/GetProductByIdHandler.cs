using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Specifications;
using MapsterMapper;
using MediatR;

namespace InventoryManagementSystem.Application.Features.ProductQueries.GetProductById
{
    public class GetProductByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetProductByIdQuery, Result<ProductToReturnDto>>
    {
        public async Task<Result<ProductToReturnDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new ProductWithDetailsSpecification(request.Id);
            var repositoryOfProducts = _unitOfWork.GetRepository<Product, int>();
            var products = await repositoryOfProducts.ListAsync(specification);
            var product = products.FirstOrDefault();
            if (product is null)
                return Result<ProductToReturnDto>.Failure("Product.NotFound", $"Product with ID {request.Id} not found.",ErrorType.NotFound);
            return Result<ProductToReturnDto>.Success(_mapper.Map<ProductToReturnDto>(product));
        }
    }
}
