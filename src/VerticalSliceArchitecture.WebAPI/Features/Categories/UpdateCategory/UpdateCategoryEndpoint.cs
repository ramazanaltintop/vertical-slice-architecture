using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.UpdateCategory;

public class UpdateCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoutes.Categories.Update, async (
            Guid id,
            [FromBody] UpdateCategoryCommand request,
            IValidator<UpdateCategoryCommand> validator,
            IUpdateCategoryHandler handler,
            CancellationToken cancellationToken) =>
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var response = await handler.HandleAsync(id, request, cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .WithName("UpdateCategory")
        .WithSummary("Update entire category")
        .WithDescription("Updates the entire category identified by the given ID.")
        .Produces<UpdateCategoryResponse>(200);
    }
}
