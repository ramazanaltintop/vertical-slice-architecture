namespace VerticalSliceArchitecture.WebAPI.Features.Categories.UpdateCategory;

public sealed record UpdateCategoryResponse(
    Guid Id,
    string Name,
    string Description);