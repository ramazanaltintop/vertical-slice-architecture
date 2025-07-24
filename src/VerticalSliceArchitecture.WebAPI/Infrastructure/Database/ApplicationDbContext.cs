using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.WebAPI.Domain.Entities;

namespace VerticalSliceArchitecture.WebAPI.Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
}
