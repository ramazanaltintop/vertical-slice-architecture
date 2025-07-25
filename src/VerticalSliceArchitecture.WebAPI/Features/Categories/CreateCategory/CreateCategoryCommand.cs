namespace VerticalSliceArchitecture.WebAPI.Features.Categories.CreateCategory;

public sealed record CreateCategoryCommand(
    string Name,
    string Description);