using Microsoft.EntityFrameworkCore;
using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\\Projetos\\Estudo\\RocketseatAuction\\db\\leilaoDbNLW.db");
        }
    }
}
