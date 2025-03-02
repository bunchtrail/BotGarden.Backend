using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class ExpositionConfiguration : IEntityTypeConfiguration<Exposition>
    {
        public void Configure(EntityTypeBuilder<Exposition> builder)
        {
            builder.ToTable("Expositions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExpositionName)
                   .HasMaxLength(100)
                   .IsRequired();
                   
            // Опциональная связь с BotGardenModel
            builder.Property(e => e.LocationId)
                   .IsRequired(false);
        }
    }
} 