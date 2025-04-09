using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.ApiService.Domain.Entities;

namespace Thunders.TechTest.ApiService.Infrastructure.Database.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
               .HasColumnType("uniqueidentifier")
               .HasDefaultValueSql("NEWID()");

        builder.Property(r => r.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(r => r.UpdatedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(r => r.DeletedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(r => r.StartedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(r => r.FinishedAt)
               .HasDefaultValueSql("NULL");

        builder.Property(r => r.ReportType)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(50);

        builder.Property(r => r.Params)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(r => r.JsonData)
               .HasColumnType("nvarchar(max)");

        builder.Property(r => r.Error)
               .HasMaxLength(1000);
    }
}