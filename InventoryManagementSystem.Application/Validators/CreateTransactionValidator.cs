using FluentValidation;
using InventoryManagementSystem.Application.DTOS;

namespace InventoryManagementSystem.Application.Validators
{
    public class CreateTransactionValidator : AbstractValidator<StockTransactionCreateDto>
    {
        public CreateTransactionValidator()
        {
            RuleFor(T => T.ProductId).NotEmpty().WithMessage("Product ID is required.");
            RuleFor(T => T.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero."); 
            RuleFor(T => T.Type).IsInEnum().WithMessage("Invalid transaction type.");   
        }
    }
}
