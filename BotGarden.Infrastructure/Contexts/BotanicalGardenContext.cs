using BotGarden.Domain.Models;
using BotGardens.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using BotGarden.Domain.Configurations;

namespace BotGarden.Infrastructure.Contexts
{
    public class BotanicGardenContext : DbContext
    {
        public BotanicGardenContext(DbContextOptions<BotanicGardenContext> options) : base(options) { }

        public DbSet<BotGardenModel>? BotGarden { get; set; }
        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<Sectors>? Sectors { get; set; }
        public DbSet<Genus>? Genus { get; set; }
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Map> Map { get; set; } = null!;

        public DbSet<Family> Families { get; set; } = null!;
        public DbSet<Exposition> Expositions { get; set; } = null!;
        public DbSet<Phenology> Phenologies { get; set; } = null!;
        public DbSet<Biometry> Biometries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            
            // Применяем все конфигурации
            modelBuilder.ApplyConfiguration(new PlantConfiguration());
            modelBuilder.ApplyConfiguration(new PhenologyConfiguration());
            modelBuilder.ApplyConfiguration(new BiometryConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new ExpositionConfiguration());
            
            // Настройка для BotGardenModel
            modelBuilder.Entity<BotGardenModel>()
                .Property(b => b.Geometry)
                .HasColumnType("geometry");

            // Настройка уникальности инвентарного номера для Plant
            modelBuilder.Entity<Plant>()
                .HasIndex(p => p.InventoryNumber)
                .IsUnique();
        }
    }
}
