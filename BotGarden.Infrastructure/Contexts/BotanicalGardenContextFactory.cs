using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BotGarden.Infrastructure.Contexts
{
    public class BotanicalGardenContextFactory : IDesignTimeDbContextFactory<BotanicGardenContext>
    {
        public BotanicGardenContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BotanicGardenContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=BotGarden;Username=postgres;Password=ezpass1",
                x => x.UseNetTopologySuite());

            return new BotanicGardenContext(optionsBuilder.Options);
        }
    }
} 