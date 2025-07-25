namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetAllCategories;

public sealed record GetAllCategoriesResponse(
    Guid Id,
    string Name,
    string Description);