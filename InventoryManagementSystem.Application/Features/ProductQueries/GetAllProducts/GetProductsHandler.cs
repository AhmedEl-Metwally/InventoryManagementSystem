using InventoryManagementSystem.Application.Common;
using InventoryManagementSystem.Application.Contracts.Repositorys;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Specifications;
using MapsterMapper;
using MediatR;

namespace InventoryManagementSystem.Application.Features.ProductQueries.GetAllProducts
{
    public class GetProductsHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetProductsQuery, Result<IEnumerable<ProductToReturnDto>>>
    {
        public async Task<Result<IEnumerable<ProductToReturnDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var specification = new ProductFilterSpecification(request.CategoryId, request.Search);
            var repositoryOfProducts = _unitOfWork.GetRepository<Product, int>();
            var products = await repositoryOfProducts.ListAsync(specification);
            var productsToReturn = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return Result<IEnumerable<ProductToReturnDto>>.Success(productsToReturn);
        }
    }
}
