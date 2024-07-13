using FiapStore.Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Infrastructure.Data.Configurations;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.ToTable("appBasketItem");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Basket)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.BasketId);

        builder.HasOne(x => x.Product)
               .WithMany()
               .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.Price)
               .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Total)
               .HasColumnType("decimal(10,2)");

        builder.Property(x => x.CreatedAt)
               .HasColumnType("datetime")
               .HasDefaultValueSql("GETDATE()");
    }
}
