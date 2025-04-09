using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Database.Configurations;

public class TollConfiguration : IEntityTypeConfiguration<Toll>
{
    public void Configure(EntityTypeBuilder<Toll> builder)
    {
        builder.ToTable("Tolls");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasColumnType("uniqueidentifier")
               .HasDefaultValueSql("NEWID()");

        builder.Property(t => t.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.UpdatedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(t => t.DeletedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(t => t.UsageDateTime)
               .IsRequired();

        builder.Property(t => t.TollBooth)
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

        builder.HasIndex(t => t.UsageDateTime)
               .HasDatabaseName("IX_UsageDateTime");

        builder.HasIndex(t => new { t.City })
               .HasDatabaseName("IX_City");

        builder.HasIndex(t => new { t.TollBooth })
               .HasDatabaseName("IX_TollBooth");

        builder.HasIndex(t => new { t.UsageDateTime, t.TollBooth })
               .HasDatabaseName("IX_UsageDateTime_TollBooth");

        builder.HasIndex(t => new { t.UsageDateTime, t.City })
               .HasDatabaseName("IX_UsageDateTime_City");
    }
}