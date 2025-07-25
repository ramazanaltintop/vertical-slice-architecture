using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetAllCategory;

public class GetAllCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Categories.GetAll, async (
            IGetAllCategoryHandler handler,
            CancellationToken cancellationToken) =>
        {
            var response = await handler.HandleAsync(cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .Produces<IList<GetAllCategoryResponse>>(200);
    }
}
