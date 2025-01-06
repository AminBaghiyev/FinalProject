using FinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.DL.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
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
            .HasMany(s => s.Products)
            .WithOne(p => p.Size)
            .HasForeignKey(p => p.SizeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
