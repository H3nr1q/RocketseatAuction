using Microsoft.EntityFrameworkCore;
using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        public RocketseatAuctionDbContext(DbContextOptions options) : base(options){}

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
