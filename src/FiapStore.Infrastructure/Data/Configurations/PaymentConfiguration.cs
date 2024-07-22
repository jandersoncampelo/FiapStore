using FiapStore.Domain.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiapStore.Domain.Payments.Entities;
using FiapStore.Domain.Orders;

namespace FiapStore.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("appPaymenties");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalPrice)                
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .IsRequired();
            builder.Property(x => x.UpdatedAt);

            builder.HasOne(x => x.Order)
                .WithOne(x => x.Payment)
                .HasForeignKey<Order>(x => x.PaymentId);
        }
    }
}
