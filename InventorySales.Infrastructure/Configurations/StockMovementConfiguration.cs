using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Configurations {
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement> {
        public void Configure(EntityTypeBuilder<StockMovement> builder) {
            builder.ToTable("StockMovements", table => {
                table.HasCheckConstraint(
                    "CK_StockMovements_Quantity_Positive",
                    "[Quantity] > 0"
                );
            });

            builder.HasKey(stockMovement => stockMovement.Id);

            builder.Property(stockMovement => stockMovement.Quantity)
                .IsRequired();

            builder.Property(stockMovement => stockMovement.MovementType)
                .IsRequired();

            builder.Property(stockMovement => stockMovement.MovementDate)
                .IsRequired();

            builder.Property(stockMovement => stockMovement.Reason)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.Property(stockMovement => stockMovement.Notes)
                .IsRequired(false)
                .HasMaxLength(500);

        }
    }
}
