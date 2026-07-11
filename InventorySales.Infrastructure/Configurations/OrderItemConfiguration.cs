using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Configurations {
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem> {
        public void Configure(EntityTypeBuilder<OrderItem> builder) {
            builder.ToTable("OrderItems", table =>
            {
                table.HasCheckConstraint(
                    "CK_OrderItems_Quantity_Positive",
                    "[Quantity] > 0"
                );

                table.HasCheckConstraint(
                    "CK_OrderItems_UnitPrice_NonNegative",
                    "[UnitPrice] >= 0"
                );

                table.HasCheckConstraint(
                    "CK_OrderItems_TotalPrice_NonNegative",
                    "[TotalPrice] >= 0"
                );
            });

            builder.HasKey(orderItem => orderItem.Id);

            builder.Property(orderItem => orderItem.Quantity)
                .IsRequired();

            builder.Property(orderItem => orderItem.UnitPrice)
                .HasPrecision(18, 2);

            builder.Property(orderItem => orderItem.TotalPrice)
                .HasPrecision(18, 2);

            builder.HasIndex(orderItem => new {
                orderItem.OrderId,
                orderItem.ProductId
            })
            .IsUnique();


        }
    }
}
