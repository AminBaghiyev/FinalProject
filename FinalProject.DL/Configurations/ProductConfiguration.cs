using FinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.DL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasOne(e => e.CreatedBy)
            .WithMany()
            .HasForeignKey(e => e.CreatedById);

        builder
            .HasOne(e => e.UpdatedBy)
            .WithMany()
            .HasForeignKey(e => e.UpdatedById)
            .IsRequired(false);

        builder
            .HasOne(e => e.DeletedBy)
            .WithMany()
            .HasForeignKey(e => e.DeletedById)
            .IsRequired(false);

        builder
            .Property(e => e.Price)
            .HasColumnType("decimal(10,2)");

        builder
            .Property(e => e.DiscountedPrice)
            .HasColumnType("decimal(10,2)");

        builder
            .Property(e => e.ColorId)
            .IsRequired(false);

        builder
            .Property(e => e.SizeId)
            .IsRequired(false);
    }
}
