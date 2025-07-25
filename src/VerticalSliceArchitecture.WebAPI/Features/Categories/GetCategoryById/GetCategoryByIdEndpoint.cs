using FluentValidation;
using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.GetCategoryById;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoutes.Categories.Get, async (
            Guid id,
            IValidator<GetCategoryByIdQuery> validator,
            IGetCategoryByIdHandler handler,
            CancellationToken cancellationToken) =>
        {
            var request = new GetCategoryByIdQuery(id);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var response = await handler.HandleAsync(request, cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .WithName("GetCategoryById")
        .WithSummary("Get category by ID")
        .WithDescription("Returns a single category identified by its ID.")
        .Produces<GetCategoryByIdResponse>(200);
    }
}
