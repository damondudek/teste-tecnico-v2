using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Database.Configurations;

public class TollConfiguration : IEntityTypeConfiguration<Toll>
{
    public void Configure(EntityTypeBuilder<Toll> builder)
    {
        builder.ToTable("Tolls");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(t => t.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.UpdatedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(t => t.DeletedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(t => t.UsageDateTime)
               .IsRequired();

        builder.Property(t => t.Plaza)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.State)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(t => t.AmountPaid)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(t => t.VehicleType)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(20);
    }
}