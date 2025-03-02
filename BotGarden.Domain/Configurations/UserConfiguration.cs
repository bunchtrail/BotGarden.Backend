using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserEmail)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.UserHashedPass)
                   .IsRequired();

            builder.Property(u => u.UserRole)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.RefreshTokenHash)
                   .IsRequired();

            builder.Property(u => u.FirstName)
                   .HasMaxLength(50);

            builder.Property(u => u.LastName)
                   .HasMaxLength(50);

            // Индекс по email для быстрого поиска и уникальности
            builder.HasIndex(u => u.UserEmail)
                   .IsUnique();
        }
    }
} 