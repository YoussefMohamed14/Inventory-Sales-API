using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Configurations {
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("Products", table => {
                table.HasCheckConstraint(
                    "CK_Products_Price_NonNegative",
                    "[Price] >= 0"
                );

                table.HasCheckConstraint(
                    "CK_Products_CostPrice_NonNegative",
                    "[CostPrice] >= 0"
                );

                table.HasCheckConstraint(
                    "CK_Products_Quantity_NonNegative",
                    "[Quantity] >= 0"
                );

                table.HasCheckConstraint(
                    "CK_Products_MinimumStock_NonNegative",
                    "[MinimumStock] >= 0"
                );
            });

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(product => product.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(product => product.SKU)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(product => product.BarCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(product => product.Price)
                .HasPrecision(18, 2);

            builder.Property(product => product.StockQuantity)
                .IsRequired();

            builder.Property(product => product.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(product => product.Name)
                .IsUnique();

            builder.HasMany(product => product.StockMovements)
                .WithOne(stockMovement => stockMovement.Product)
                .HasForeignKey(stockMovement => stockMovement.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(product => product.OrderItems)
                .WithOne(orderItem => orderItem.Product)
                .HasForeignKey(orderItem => orderItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
