using BotGarden.Domain.Models;
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
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Map> Maps { get; set; } = null!;

        public DbSet<Family> Families { get; set; } = null!;
        public DbSet<Exposition> Expositions { get; set; } = null!;
        public DbSet<Phenology> Phenologies { get; set; } = null!;
        public DbSet<Biometry> Biometries { get; set; } = null!;
        
        // Новые DbSet для таблиц, связанных с пользователями
        public DbSet<UserFavorite> UserFavorites { get; set; } = null!;
        public DbSet<UserVisit> UserVisits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            
            // Применяем все конфигурации
            modelBuilder.ApplyConfiguration(new PlantConfiguration());
            modelBuilder.ApplyConfiguration(new PhenologyConfiguration());
            modelBuilder.ApplyConfiguration(new BiometryConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new ExpositionConfiguration());
            modelBuilder.ApplyConfiguration(new MapConfiguration());
            modelBuilder.ApplyConfiguration(new GenusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            // Настройка для BotGardenModel
            modelBuilder.Entity<BotGardenModel>()
                .Property(b => b.Geometry)
                .HasColumnType("geometry");

            // Настройка связи между BotGardenModel и Exposition (один-к-одному)
            modelBuilder.Entity<BotGardenModel>()
                .HasOne(b => b.Exposition)
                .WithOne(e => e.Location)
                .HasForeignKey<Exposition>(e => e.LocationId);

            // Настройка уникальности инвентарного номера для Plant
            modelBuilder.Entity<Plant>()
                .HasIndex(p => p.InventoryNumber)
                .IsUnique();
                
            // Настройка связей для User и Plant (аудит)
            modelBuilder.Entity<Plant>()
                .HasOne(p => p.CreatedBy)
                .WithMany(u => u.CreatedPlants)
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
                
            modelBuilder.Entity<Plant>()
                .HasOne(p => p.ModifiedBy)
                .WithMany(u => u.ModifiedPlants)
                .HasForeignKey(p => p.ModifiedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
                
            // Настройка для UserFavorite
            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.Plant)
                .WithMany()
                .HasForeignKey(uf => uf.PlantId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Настройка для UserVisit
            modelBuilder.Entity<UserVisit>()
                .HasOne(uv => uv.User)
                .WithMany(u => u.Visits)
                .HasForeignKey(uv => uv.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
