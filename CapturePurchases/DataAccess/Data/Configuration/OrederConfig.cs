using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelsConfiguration;


public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.OrderId);

        builder.Property(e => e.OrderDate)
            .HasColumnType("DATETIME")
            .IsRequired();

        //> One-to-Many Relationship (Customer - Order)
        builder.HasOne(e => e.Customer)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.CustomerId)
            .IsRequired();
    }
}