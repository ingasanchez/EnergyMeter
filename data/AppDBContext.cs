using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestEnergyProject.data
{
    public class AppDBContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public AppDBContext()
        {

        }

        public AppDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("webApiDatabase"));
        }

        public DbSet<power_readings> power_readings => Set<power_readings>();

    }
}
