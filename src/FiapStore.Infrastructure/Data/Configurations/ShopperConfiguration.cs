using FiapStore.Domain.Shoppers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Infrastructure.Data;

public class ShopperConfiguration : IEntityTypeConfiguration<Shopper>
{
    public void Configure(EntityTypeBuilder<Shopper> builder)
    {
        builder.ToTable("appShoppers");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(128);
    }
}
