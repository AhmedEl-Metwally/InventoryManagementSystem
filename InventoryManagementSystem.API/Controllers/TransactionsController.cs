using InventoryManagementSystem.Application.Commands.StockTransactions;
using InventoryManagementSystem.Application.DTOS;
using InventoryManagementSystem.Application.Features.TransactionsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    public class TransactionsController(IMediator _mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTransactionAsync([FromBody] StockTransactionCreateDto stockTransactionCreateDto)
        {
            var result = await _mediator.Send(new CreateTransactionCommand(stockTransactionCreateDto));
            return HandleResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsAsync()
        {
            var result = await _mediator.Send(new GetTransactionsQuery());
            return HandleResult(result);
        }
    }
}

