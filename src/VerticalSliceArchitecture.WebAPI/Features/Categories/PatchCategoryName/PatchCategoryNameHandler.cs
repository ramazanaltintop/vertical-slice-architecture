using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.PatchCategoryName;

public interface IPatchCategoryNameHandler
{
    Task<PatchCategoryNameResponse> HandleAsync(Guid id, PatchCategoryNameCommand request, CancellationToken cancellationToken);
}

public class PatchCategoryNameHandler(
    ApplicationDbContext context) : IPatchCategoryNameHandler
{
    public async Task<PatchCategoryNameResponse> HandleAsync(Guid id, PatchCategoryNameCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new Exception("Category not found");

        category.Name = request.Name;

        category = context.Categories.Update(category).Entity;

        await context.SaveChangesAsync(cancellationToken);

        return new(category.Id, category.Name, category.Description);
    }
}
