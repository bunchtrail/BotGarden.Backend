using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class BiometryConfiguration : IEntityTypeConfiguration<Biometry>
    {
        public void Configure(EntityTypeBuilder<Biometry> builder)
        {
            builder.ToTable("Biometries");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.MeasurementDate)
                   .IsRequired();

            builder.Property(b => b.MeasurementType)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(b => b.Notes)
                   .HasColumnType("text")
                   .IsRequired();

            builder.HasOne(b => b.Plant)
                   .WithMany(p => p.Biometries)
                   .HasForeignKey(b => b.PlantId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 