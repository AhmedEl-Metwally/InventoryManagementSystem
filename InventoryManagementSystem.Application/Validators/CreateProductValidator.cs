using FluentValidation;
using InventoryManagementSystem.Application.DTOS;

namespace InventoryManagementSystem.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductCreateDto>
    {
        public CreateProductValidator()
        {
            RuleFor(P => P.Name).NotEmpty().WithMessage("Product name is required.")
                                         .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(P => P.Price).GreaterThan(0).WithMessage("Product price must be greater than 0.");
        }
    }
}
