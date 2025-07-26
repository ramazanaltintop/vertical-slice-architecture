using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Scrutor;
using VerticalSliceArchitecture.WebAPI.Common.Exceptions;
using VerticalSliceArchitecture.WebAPI.Common.Extensions;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(configure =>
{
    configure.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
    };
});
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Scan(options => options
    .FromAssembliesOf(typeof(Program))
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Handler")))
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddOpenApi();

builder.Services.AddEndpoints(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.UseExceptionHandler();

app.Run();
