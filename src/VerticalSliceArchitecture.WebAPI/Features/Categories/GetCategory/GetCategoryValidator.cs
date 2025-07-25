using FluentValidation;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategory;

public sealed class GetCategoryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Category can not be empty")
            .NotNull().WithMessage("Category can not be empty");
    }
}
