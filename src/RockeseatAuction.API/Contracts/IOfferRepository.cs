using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
