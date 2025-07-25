using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategoryById;

public interface IGetCategoryByIdHandler
{
    Task<GetCategoryByIdResponse> HandleAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken);
}

public sealed class GetCategoryByIdHandler(
    ApplicationDbContext context) : IGetCategoryByIdHandler
{
    public async Task<GetCategoryByIdResponse> HandleAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Where(p => p.IsDeleted == false)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                ?? throw new Exception("Category not found");

        return new(category.Id, category.Name, category.Description);
    }
}
