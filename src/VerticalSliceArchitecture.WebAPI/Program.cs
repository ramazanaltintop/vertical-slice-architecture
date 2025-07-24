using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VerticalSliceArchitecture.WebAPI.Common.Extensions;
using VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

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

app.Run();
