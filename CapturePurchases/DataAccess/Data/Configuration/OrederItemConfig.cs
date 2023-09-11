using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelsConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => new { e.ItemId, e.OrderId});

        builder.Property(e => e.ListPrice)
            .HasColumnType("DECIMAL(12, 2)")
            .IsRequired();

        //> One-to-Many Relationship (Order - OrderItem)
        builder.HasOne(e => e.Order)   
            .WithMany(e => e.OrderItems)
            .HasForeignKey(e => e.OrderId)
            .IsRequired();
    }
}