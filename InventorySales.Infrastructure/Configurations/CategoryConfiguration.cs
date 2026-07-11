using InventorySales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InventorySales.Infrastructure.Configurations {
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.ToTable("Categories");

            builder.HasKey(category => category.Id);

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(category => category.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasIndex(category => category.Name)
                .IsUnique();

            builder.HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
