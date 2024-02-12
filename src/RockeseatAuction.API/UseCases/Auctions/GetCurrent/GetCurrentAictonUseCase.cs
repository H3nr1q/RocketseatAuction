using RockeseatAuction.API.Repositories;
using RockeseatAuction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace RockeseatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAictonUseCase
    {
        public Auction? Execute()
        {
            var repository = new RocketseatAuctionDbContext();

            var today = DateTime.Now;
            
            return repository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
