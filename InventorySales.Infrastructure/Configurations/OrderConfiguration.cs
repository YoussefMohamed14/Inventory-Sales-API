using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Configurations {
    public class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.ToTable("Orders", table => {
                table.HasCheckConstraint(
                    "CK_Orders_TotalAmount_NonNegative",
                    "[TotalAmount] >= 0"
                );
            });

            builder.HasKey(order => order.Id);

            builder.Property(order => order.OrderDate)
                .IsRequired();

            builder.Property(order => order.TotalAmount)
                .HasPrecision(18, 2);

            builder.Property(order => order.Status)
                .IsRequired();

            builder.Property(order => order.Notes)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
