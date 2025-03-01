using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BotGarden.Infrastructure.Contexts
{
    public class BotanicalGardenContextFactory : IDesignTimeDbContextFactory<BotanicGardenContext>
    {
        public BotanicGardenContext CreateDbContext(string[] args)
        {
            // Читаем конфигурацию из appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("BotanicalDb");
            
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Host=localhost;Database=BotGarden;Username=postgres;Password=ezpass1";
            }

            var optionsBuilder = new DbContextOptionsBuilder<BotanicGardenContext>();
            optionsBuilder.UseNpgsql(connectionString,
                x => x.UseNetTopologySuite());

            return new BotanicGardenContext(optionsBuilder.Options);
        }
    }
} 