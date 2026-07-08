using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Configurations {
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier> {
        public void Configure(EntityTypeBuilder<Supplier> builder) {

            builder.ToTable("Suppliers");
            
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Phone)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(s => s.Address)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasIndex(s => s.Email)
                .IsUnique();

            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(s => s.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
