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
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var response = await handler.HandleAsync(id, request, cancellationToken);

            return Results.Ok(response);
        })
        .WithTags("Categories")
        .Produces<UpdateCategoryResponse>(200);
    }
}
