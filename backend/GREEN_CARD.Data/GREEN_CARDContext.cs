 
using Microsoft.EntityFrameworkCore;
using GREEN_CARD.Core.Models;
using System.Threading;
using System.Runtime.CompilerServices;

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
        
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            //Configure default schema
            // modelBuilder.Entity<Transaction>()
            // .Property(f => f.TransactionId)
            // .ValueGeneratedOnAdd();
                    
            // modelBuilder.Entity<Item>()
            // .Property(f => f.ItemId)
            // .ValueGeneratedOnAdd();

            // modelBuilder.Entity<Receipt>()
            // .Property(f => f.ReceiptId)
            // .ValueGeneratedOnAdd();
            //Map entity to table
            modelBuilder.ForNpgsqlUseIdentityColumns();
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<User> Users{get;set;}
        public DbSet<Transaction> Transactions{get;set;}
        public DbSet<Item> Items{get;set;}
        public DbSet<Receipt> Receipts{get;set;}
        public DbSet<SkaterStatistic> SkaterStatistics { get; set; }
        
    }
}
