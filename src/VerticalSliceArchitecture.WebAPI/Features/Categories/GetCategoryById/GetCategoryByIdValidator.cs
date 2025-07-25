using FluentValidation;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategoryById;

public sealed class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Category can not be empty")
            .NotNull().WithMessage("Category can not be empty");
    }
}
