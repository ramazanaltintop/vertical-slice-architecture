using VerticalSliceArchitecture.WebAPI.Domain.Bases;

namespace VerticalSliceArchitecture.WebAPI.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
