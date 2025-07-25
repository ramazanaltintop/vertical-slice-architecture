namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetAllCategory;

public sealed record GetAllCategoryResponse(
    Guid Id,
    string Name,
    string Description);