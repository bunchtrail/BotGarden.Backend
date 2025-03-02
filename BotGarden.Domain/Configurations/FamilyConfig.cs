using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.ToTable("Families");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.FamilyName)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
} 