using Microsoft.EntityFrameworkCore;
using BotGardens.Domain.Entities;

namespace BotGardens.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<PhenologicalData> PhenologicalDatas { get; set; }
        public DbSet<BiometricData> BiometricDatas { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>()
                .HasIndex(p => p.InventoryNumber)
                .IsUnique();

            modelBuilder.Entity<Plant>()
                .HasOne(p => p.Family)
                .WithMany()
                .HasForeignKey(p => p.FamilyID);

            modelBuilder.Entity<Plant>()
                .HasOne(p => p.Location)
                .WithMany()
                .HasForeignKey(p => p.LocationID);

            modelBuilder.Entity<Plant>()
                .HasOne(p => p.Sector)
                .WithMany(s => s.Plants)
                .HasForeignKey(p => p.SectorID);

            modelBuilder.Entity<PhenologicalData>()
                .HasOne(p => p.Plant)
                .WithMany(pl => pl.PhenologicalDatas)
                .HasForeignKey(p => p.InventoryNumber)
                .HasPrincipalKey(pl => pl.InventoryNumber);

            modelBuilder.Entity<BiometricData>()
                .HasOne(b => b.Plant)
                .WithMany(pl => pl.BiometricDatas)
                .HasForeignKey(b => b.InventoryNumber)
                .HasPrincipalKey(pl => pl.InventoryNumber);
        }
    }
}
