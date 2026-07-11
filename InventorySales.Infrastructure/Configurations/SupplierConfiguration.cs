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

            builder.HasKey(supplier => supplier.Id);

            builder.Property(supplier => supplier.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(supplier => supplier.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(supplier => supplier.Email)
                .IsUnique();

            builder.Property(supplier => supplier.Phone)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(supplier => supplier.Address)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.HasMany(supplier => supplier.Products)
                .WithOne(product => product.Supplier)
                .HasForeignKey(product => product.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
