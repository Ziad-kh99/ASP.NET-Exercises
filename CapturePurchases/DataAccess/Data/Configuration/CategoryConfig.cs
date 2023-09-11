using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelsConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.CategoryId);

        builder.Property(e => e.CategoryName)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        //> One-to-Many Relationship (Category - Product)
        builder.HasMany(e => e.Products)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();
    }
}