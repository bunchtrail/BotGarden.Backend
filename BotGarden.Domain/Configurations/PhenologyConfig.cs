using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class PhenologyConfiguration : IEntityTypeConfiguration<Phenology>
    {
        public void Configure(EntityTypeBuilder<Phenology> builder)
        {
            builder.ToTable("Phenologies");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Year)
                   .IsRequired();

            builder.Property(p => p.Notes)
                   .HasColumnType("text")
                   .IsRequired();

            builder.HasOne(p => p.Plant)
                   .WithMany(p => p.Phenologies)
                   .HasForeignKey(p => p.PlantId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 