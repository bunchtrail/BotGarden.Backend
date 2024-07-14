using BotGarden.Domain.Models;
using BotGardens.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace BotGarden.Infrastructure.Contexts
{
    public class BotanicGardenContext : DbContext
    {
        public BotanicGardenContext(DbContextOptions<BotanicGardenContext> options) : base(options) { }

        public DbSet<BotGardenMode>? BotGarden { get; set; }
        public DbSet<Collections>? Collections { get; set; }
        public DbSet<PlantFamilies>? PlantFamilies { get; set; }
        public DbSet<Plants>? Plants { get; set; }
        public DbSet<Sectors>? Sectors { get; set; }
        public DbSet<Genus>? Genus { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.ApplyConfiguration(new PlantsConfiguration());

            modelBuilder.Entity<BotGardenMode>()
                .Property(b => b.Geometry)
                .HasColumnType("geometry");
        }
    }
}
