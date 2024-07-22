using FiapStore.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Infrastructure.Data.Configurations;

public class OrderConfigration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("appOrders");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        builder.Property(x => x.Total)
               .HasColumnType("decimal(10,2)");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()")
               .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedAt)
               .HasDefaultValueSql("GETDATE()")
               .ValueGeneratedOnAddOrUpdate();

        builder.HasMany(x => x.Payments)
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId);

    }
}
