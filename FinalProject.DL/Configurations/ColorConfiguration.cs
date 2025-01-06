using FinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.DL.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
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
            .HasMany(c => c.Products)
            .WithOne(p => p.Color)
            .HasForeignKey(p => p.ColorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
