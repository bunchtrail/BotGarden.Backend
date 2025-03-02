using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class GenusConfiguration : IEntityTypeConfiguration<Genus>
    {
        public void Configure(EntityTypeBuilder<Genus> builder)
        {
            builder.ToTable("Genera");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.GenusName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasMany(g => g.Plants)
                   .WithOne(p => p.Genus)
                   .HasForeignKey(p => p.GenusId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
} 