using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetAllCategories;

public interface IGetAllCategoriesHandler
{
    Task<IList<GetAllCategoriesResponse>> HandleAsync(CancellationToken cancellationToken);
}

public class GetAllCategoriesHandler(
    ApplicationDbContext context) : IGetAllCategoriesHandler
{
    public async Task<IList<GetAllCategoriesResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        return await context.Categories
            .Where(p => p.IsDeleted == false)
            .Select(s => new GetAllCategoriesResponse(
                s.Id,
                s.Name,
                s.Description))
            .ToListAsync(cancellationToken);
    }
}
