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
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var response = await handler.HandleAsync(id, request, cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .Produces<PatchCategoryNameResponse>(200);
    }
}
