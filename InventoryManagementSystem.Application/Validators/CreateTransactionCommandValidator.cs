using FluentValidation;
using InventoryManagementSystem.Application.Commands.StockTransactions;
using InventoryManagementSystem.Application.DTOS;

namespace InventoryManagementSystem.Application.Validators
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator(IValidator<StockTransactionCreateDto> dtoValidator)
        {
            RuleFor(T => T.TransactionCreateDto).SetValidator(dtoValidator);
        }
    }
}
