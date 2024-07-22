using FiapStore.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Infrastructure.Data.Configurations;

public class OrdemItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("appOrderItem");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Total)
            .HasColumnType("decimal(10,2)");

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.OrderId);
    }
}
