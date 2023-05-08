using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations;

internal class LineConfiguration: IEntityTypeConfiguration<Line>
{
    public void Configure(EntityTypeBuilder<Line> builder)
    {
        builder.ToTable("line");
        builder.HasKey(line => line.Id);
        builder
            .Property(line => line.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder
            .Property(line => line.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder
            .Property(line => line.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder
            .HasOne(line => line.Order)
            .WithMany(order => order.Lines)
            .HasForeignKey(line => line.OrderId);
    }
}