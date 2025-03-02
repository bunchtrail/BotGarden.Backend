using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BotGarden.Domain.Models;

namespace BotGarden.Domain.Configurations
{
    /// <summary>
    /// Конфигурация для модели Map, определяющая настройки таблицы в БД
    /// </summary>
    public class MapConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.ToTable("Maps");

            builder.HasKey(m => m.MapImageId);

            builder.Property(m => m.MapImagePath)
                  .IsRequired()
                  .HasMaxLength(500);

            builder.Property(m => m.MapDescription)
                  .HasMaxLength(255)
                  .IsRequired(false);
        }
    }
} 