using BotGarden.Domain.Models;
using BotGardens.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace BotGarden.Infrastructure.Contexts
{
    public class BotanicGardenContext : DbContext
    {
        public BotanicGardenContext(DbContextOptions<BotanicGardenContext> options) : base(options) { }

        public DbSet<BotGardenModel>? BotGarden { get; set; }
        public DbSet<Collections>? Collections { get; set; }
        public DbSet<PlantFamilies>? PlantFamilies { get; set; }
        public DbSet<Plants>? Plants { get; set; }
        public DbSet<Sectors>? Sectors { get; set; }
        public DbSet<Genus>? Genus { get; set; }
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Map> Map { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            
            // Применяем все существующие конфигурации
            modelBuilder.ApplyConfiguration(new PlantsConfiguration());
            
            // Настройка для BotGardenModel
            modelBuilder.Entity<BotGardenModel>()
                .Property(b => b.Geometry)
                .HasColumnType("geometry");
        }
    }
}
