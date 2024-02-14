using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Contracts
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
