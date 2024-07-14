using BotGarden.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BotGarden.Infrastructure.Contexts
{
    public class DesignTimeBotanicGardenContextFactory : IDesignTimeDbContextFactory<BotanicGardenContext>
    {
        public BotanicGardenContext CreateDbContext(string[] args)
        {
            // Указываем путь к файлу appsettings.json в проекте BotGarden.Web
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../BotGarden.Infrastructure");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BotanicGardenContext>();
            var connectionString = configuration.GetConnectionString("BotanicalDb");

            builder.UseNpgsql(connectionString, x => x.UseNetTopologySuite());

            return new BotanicGardenContext(builder.Options);
        }
    }
}
