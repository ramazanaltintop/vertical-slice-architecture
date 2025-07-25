using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.DeleteCategory;

public interface IDeleteCategoryHandler
{
    Task<bool> HandleAsync(Guid id, CancellationToken cancellationToken);
}

public class DeleteCategoryHandler(
    ApplicationDbContext context) : IDeleteCategoryHandler
{
    public async Task<bool> HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Where(c => c.IsDeleted == false)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category is null)
            return false;

        category.IsDeleted = true;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
