using VerticalSliceArchitecture.WebAPI.Domain.Entities;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.CreateCategory;

public interface ICreateCategoryHandler
{
    Task<CreateCategoryResponse> HandleAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
}

public class CreateCategoryHandler(
    ApplicationDbContext context) : ICreateCategoryHandler
{
    public async Task<CreateCategoryResponse> HandleAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new()
        {
            Name = request.Name,
            Description = request.Description
        };

        var entry = await context.Categories.AddAsync(category, cancellationToken);

        category = entry.Entity;

        await context.SaveChangesAsync(cancellationToken);

        return new(category.Id, category.Name, category.Description);
    }
}
