namespace VerticalSliceArchitecture.WebAPI.Features.Categories.PatchCategoryName;

public sealed record PatchCategoryNameResponse(
    Guid Id,
    string Name,
    string Description);