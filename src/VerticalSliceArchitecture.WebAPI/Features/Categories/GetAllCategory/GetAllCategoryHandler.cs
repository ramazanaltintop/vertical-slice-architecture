using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetAllCategory;

public interface IGetAllCategoryHandler
{
    Task<IList<GetAllCategoryResponse>> HandleAsync(CancellationToken cancellationToken);
}

public class GetAllCategoryHandler(
    ApplicationDbContext context) : IGetAllCategoryHandler
{
    public async Task<IList<GetAllCategoryResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        return await context.Categories
            .Where(p => p.IsDeleted == false)
            .Select(s => new GetAllCategoryResponse(
                s.Id,
                s.Name,
                s.Description))
            .ToListAsync(cancellationToken);
    }
}
