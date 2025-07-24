using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerticalSliceArchitecture.WebAPI.Domain.Entities;

namespace VerticalSliceArchitecture.WebAPI.Infrastructure.Database.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(p => p.StockQuantity)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("money");

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
    }
}
