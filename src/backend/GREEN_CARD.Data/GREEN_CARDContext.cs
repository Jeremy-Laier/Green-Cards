 
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Models;

namespace GREEN_CARD.Data
{
    public sealed class GREEN_CARDContext : DbContext
    {
        public GREEN_CARDContext(DbContextOptions options)
            : base(options)
        {
           // these are mutually exclusive, migrations cannot be used with EnsureCreated()
           // Database.EnsureCreated();
           Database.Migrate();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<SkaterStatistic> SkaterStatistics { get; set; }
        
    }
}
