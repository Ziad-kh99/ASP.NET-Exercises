using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelsConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.CustomerId);

        builder.Property(e => e.FirstName)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
            
        builder.Property(e => e.LastName)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        
        builder.Property(e => e.Address)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(e => e.Email)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(e => e.Phone)
            .HasColumnType("VARCHAR(30)")
            .IsRequired();
    }
}