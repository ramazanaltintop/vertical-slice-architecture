using FluentValidation;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.PatchCategoryName;

public sealed class PatchCategoryNameValidator : AbstractValidator<PatchCategoryNameCommand>
{
    public PatchCategoryNameValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Category name cannot be empty")
            .NotNull().WithMessage("Category name cannot be empty")
            .MinimumLength(2).WithMessage("Category name must be at least 2 characters");
    }
}
