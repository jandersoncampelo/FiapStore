using FiapStore.Domain.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiapStore.Domain.Payments.Entities;
using FiapStore.Domain.Orders;

namespace FiapStore.Infrastructure.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("appPayments");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.TransactionId)
               .IsRequired();

        builder.Property(p => p.Amount)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();
            builder.Property(x => x.UpdatedAt);

        builder.HasOne(p => p.Order)
               .WithMany(o => o.Payments)
               .HasForeignKey(p => p.OrderId);
    }
}
