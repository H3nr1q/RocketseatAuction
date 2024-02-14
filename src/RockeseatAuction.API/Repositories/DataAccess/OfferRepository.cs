using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly RocketseatAuctionDbContext dbContext;
        public OfferRepository(RocketseatAuctionDbContext dbContext) => this.dbContext = dbContext;
        public void Add(Offer offer)
        {
            this.dbContext.Offers.Add(offer);
            this.dbContext.SaveChanges();
        }
    }
}
