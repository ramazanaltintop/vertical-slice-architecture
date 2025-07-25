namespace VerticalSliceArchitecture.WebAPI.Features.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(
    string Name,
    string Description);