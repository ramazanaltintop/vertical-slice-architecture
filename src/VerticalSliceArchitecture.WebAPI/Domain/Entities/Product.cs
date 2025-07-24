using VerticalSliceArchitecture.WebAPI.Domain.Bases;

namespace VerticalSliceArchitecture.WebAPI.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
