using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategory;

public interface IGetCategoryHandler
{
    Task<GetCategoryResponse> HandleAsync(GetCategoryQuery request, CancellationToken cancellationToken);
}

public sealed class GetCategoryHandler(
    ApplicationDbContext context) : IGetCategoryHandler
{
    public async Task<GetCategoryResponse> HandleAsync(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Where(p => p.IsDeleted == false)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                ?? throw new Exception("Category not found");

        return new(category.Id, category.Name, category.Description);
    }
}
