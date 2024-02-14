using Microsoft.EntityFrameworkCore;
using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly RocketseatAuctionDbContext dbContext;
        public AuctionRepository(RocketseatAuctionDbContext dbContext) => this.dbContext = dbContext;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;

            return dbContext
               .Auctions
               .Include(auction => auction.Items)
               .FirstOrDefault();
               //.FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
