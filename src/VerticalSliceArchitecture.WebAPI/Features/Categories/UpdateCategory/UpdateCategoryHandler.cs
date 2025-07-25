using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.UpdateCategory;

public interface IUpdateCategoryHandler
{
    Task<UpdateCategoryResponse> HandleAsync(Guid id, UpdateCategoryCommand request, CancellationToken cancellationToken);
}

public class UpdateCategoryHandler(
    ApplicationDbContext context) : IUpdateCategoryHandler
{
    public async Task<UpdateCategoryResponse> HandleAsync(Guid id, UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new Exception("Category not found");

        category.Name = request.Name;
        category.Description = request.Description;

        category = context.Categories.Update(category).Entity;

        await context.SaveChangesAsync(cancellationToken);

        return new(category.Id, category.Name, category.Description);
    }
}
