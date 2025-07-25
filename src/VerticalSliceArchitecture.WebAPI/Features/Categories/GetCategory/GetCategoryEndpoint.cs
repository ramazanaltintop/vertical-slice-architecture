using FluentValidation;
using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategory;

public class GetCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Categories.Get, async (
            Guid id,
            IValidator<GetCategoryQuery> validator,
            IGetCategoryHandler handler,
            CancellationToken cancellationToken) =>
        {
            var request = new GetCategoryQuery(id);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var response = await handler.HandleAsync(request, cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .Produces<GetCategoryResponse>(200);
    }
}
