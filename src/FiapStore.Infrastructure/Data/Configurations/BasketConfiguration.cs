using FiapStore.Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Infrastructure.Data.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.ToTable("appBasket");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Items)
               .WithOne()
               .HasForeignKey(x => x.BasketId);

        builder.HasOne(x => x.Shopper)
               .WithOne()
               .HasForeignKey<Basket>(x => x.Id);

        builder.Property(x => x.Total)
               .HasColumnType("decimal(10,2)");

        builder.Property(x => x.CreatedAt)
               .HasColumnType("datetime")
               .HasDefaultValueSql("GETDATE()");
    }
}
