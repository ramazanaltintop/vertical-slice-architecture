using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.PatchCategoryName;

public class PatchCategoryNameEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch(ApiRoutes.Categories.Patch, async (
            Guid id,
            [FromBody] PatchCategoryNameCommand request,
            IValidator<PatchCategoryNameCommand> validator,
            IPatchCategoryNameHandler handler,
            CancellationToken cancellationToken) =>
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var response = await handler.HandleAsync(id, request, cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .WithName("PatchCategoryName")
        .WithSummary("Partially update category")
        .WithDescription("Updates name field of the category identified by the given ID.")
        .Produces<PatchCategoryNameResponse>(200);
    }
}
