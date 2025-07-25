using FluentValidation;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.CreateCategory;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Category name cannot be empty")
            .NotNull().WithMessage("Category name cannot be empty")
            .MinimumLength(2).WithMessage("Category name must be at least 2 characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Category description cannot be empty")
            .NotNull().WithMessage("Category description cannot be empty")
            .MinimumLength(2).WithMessage("Category description must be at least 2 characters");
    }
}
