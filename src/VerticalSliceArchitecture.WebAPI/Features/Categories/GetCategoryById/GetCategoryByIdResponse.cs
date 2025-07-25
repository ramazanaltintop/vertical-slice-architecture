namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategoryById;

public sealed record GetCategoryByIdResponse(
    Guid Id,
    string Name,
    string Description);