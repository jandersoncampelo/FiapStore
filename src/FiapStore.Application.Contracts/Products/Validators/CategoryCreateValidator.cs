using FiapStore.Application.Contracts.Category;
using FluentValidation;

namespace FiapStore.Application.Contracts.Products
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .MinimumLength(3)
                    .WithMessage("Name must be at least 3 characters")
                .MaximumLength(128)
                    .WithMessage("Name must be less than 128 characters");

            RuleFor(x => x.Description)
                .MaximumLength(255)
                    .WithMessage("Description must be less than 255 characters");


        }
    }
}
