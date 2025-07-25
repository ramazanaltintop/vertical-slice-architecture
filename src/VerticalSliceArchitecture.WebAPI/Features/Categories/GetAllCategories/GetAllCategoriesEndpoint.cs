using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetAllCategories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Categories.Base, async (
            IGetAllCategoriesHandler handler,
            CancellationToken cancellationToken) =>
        {
            var response = await handler.HandleAsync(cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .WithName("GetAllCategories")
        .WithSummary("Get all categories")
        .WithDescription("Returns the full list of categories.")
        .Produces<IList<GetAllCategoriesResponse>>(200);
    }
}
