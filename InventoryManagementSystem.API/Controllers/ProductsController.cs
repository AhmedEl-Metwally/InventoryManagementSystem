using InventoryManagementSystem.Application.Commands.CreateProduct;
using InventoryManagementSystem.Application.Commands.Products.DeleteProduct;
using InventoryManagementSystem.Application.Commands.Products.UpdateProduct;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Application.Features.ProductQueries.GetAllProducts;
using InventoryManagementSystem.Application.Features.ProductQueries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    public class ProductsController(IMediator _mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync([FromQuery] int? CategoryId, [FromQuery] string? Search)
        {
            var query = new GetProductsQuery(CategoryId, Search);
            return HandleResult(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetProductByIdQuery(id);
            return HandleResult(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            var command = new CreateProductCommand(productCreateDto);
            var result = await _mediator.Send(command);
            //if (result.IsSuccess && result.Value is not null)
            //    return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Value.Id }, result);
            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
        {
            var command = new UpdateProductCommand(id, productUpdateDto);
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var command  = new DeleteProductCommand(Id);
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
                return NoContent();
            return HandleResult(result);
        }
    }
}
