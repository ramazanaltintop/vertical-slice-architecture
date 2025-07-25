﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArchitecture.WebAPI.Common.Abstractions;
using VerticalSliceArchitecture.WebAPI.Common.Constants;

namespace VerticalSliceArchitecture.WebAPI.Features.Categories.CreateCategory;

public sealed class CreateCategoryEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoutes.Categories.Base, async (
            [FromBody] CreateCategoryCommand request,
            IValidator<CreateCategoryCommand> validator,
            ICreateCategoryHandler handler,
            CancellationToken cancellationToken) =>
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            
            var response = await handler.HandleAsync(request, cancellationToken);

            return Results.Created($"{ApiRoutes.Categories.Base}/{response.Id}", response);
        })
        .WithTags("Categories")
        .WithName("CreateCategory")
        .WithSummary("Create a new category")
        .WithDescription("Creates a new category with the given data.")
        .Produces<CreateCategoryResponse>(201);
    }
}
