using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Configurations {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.ToTable("Customers");

            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(customer => customer.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(customer => customer.Email)
                .IsUnique();

            builder.Property(customer => customer.Phone)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(customer => customer.Address)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
