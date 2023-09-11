using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelsConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.ProductId);

        builder.Property(e => e.ProductName)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(e => e.ListPrice)
            .HasColumnType("DECIMAL(12, 2)")
            .IsRequired();

        //> One-to-Many Relationship (Product - OrderItem)
        builder.HasMany(e => e.OrderItems)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.ProductId);
    }
}