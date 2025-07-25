namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategory;

public sealed record GetCategoryResponse(
    Guid Id,
    string Name,
    string Description);