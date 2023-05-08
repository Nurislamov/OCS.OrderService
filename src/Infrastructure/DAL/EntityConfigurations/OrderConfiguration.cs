using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");
        builder
            .Property(order => order.Id)
            .HasColumnName("order_id")
            .ValueGeneratedNever()
            .IsRequired();
        
        builder
            .Property(order => order.Status)
            .HasColumnName("order_status")
            .IsRequired();
        
        builder
            .Property(order => order.CreatedDateTime)
            .HasColumnName("created_datetime")
            .IsRequired();
    }
}