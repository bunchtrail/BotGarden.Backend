using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.ToTable("Plants");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.InventoryNumber)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Rod)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Vid)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Sort)
                   .HasMaxLength(50);

            builder.Property(p => p.Forma)
                   .HasMaxLength(50);

            builder.Property(p => p.Synonyms)
                   .HasMaxLength(250);

            builder.Property(p => p.Origin)
                   .HasMaxLength(250);

            builder.Property(p => p.Areal)
                   .HasMaxLength(250);

            builder.Property(p => p.EcologyBiology)
                   .HasMaxLength(250);

            builder.Property(p => p.EconomicUse)
                   .HasMaxLength(250);

            builder.Property(p => p.DeterminedBy)
                   .HasMaxLength(50);

            builder.Property(p => p.SecurityStatus)
                   .HasMaxLength(50);

            builder.Property(p => p.Originator)
                   .HasMaxLength(250);

            builder.Property(p => p.YearCountry)
                   .HasMaxLength(250);

            builder.Property(p => p.Illustration)
                   .HasMaxLength(250);

            builder.Property(p => p.FilledBy)
                   .HasMaxLength(50);

            builder.Property(p => p.Notes)
                   .HasColumnType("text");

            builder.HasOne(p => p.Family)
                   .WithMany(f => f.Plants)
                   .HasForeignKey(p => p.FamilyId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Exposition)
                   .WithMany(e => e.Plants)
                   .HasForeignKey(p => p.ExpositionId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Genus)
                   .WithMany(g => g.Plants)
                   .HasForeignKey(p => p.GenusId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
} 