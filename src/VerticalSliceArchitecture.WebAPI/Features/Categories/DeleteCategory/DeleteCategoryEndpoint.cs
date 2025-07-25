using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.DeleteCategory;

public class DeleteCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiRoutes.Categories.Delete, async (
            Guid id,
            IDeleteCategoryHandler handler,
            CancellationToken cancellationToken) =>
        {
            bool result = await handler.HandleAsync(id, cancellationToken);

            if (!result)
            {
                return Results.NotFound();
            }

            return Results.Ok(new { Message = "Category was successfully deleted" });
        })
        .WithTags("Categories")
        .WithName("DeleteCategory")
        .WithSummary("Delete category")
        .WithDescription("Deletes the category identified by the given ID.");
    }
}
