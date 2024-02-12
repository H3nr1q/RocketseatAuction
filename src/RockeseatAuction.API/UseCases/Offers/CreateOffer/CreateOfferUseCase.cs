using RockeseatAuction.API.Communication.Requests;
using RockeseatAuction.API.Entities;
using RockeseatAuction.API.Repositories;
using RockeseatAuction.API.Services;

namespace RockeseatAuction.API.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser loggedUser;
        public CreateOfferUseCase(LoggedUser loggedUser) => this.loggedUser = loggedUser;
        
        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var repository = new RocketseatAuctionDbContext();

            var user = this.loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,

            };

            repository.Offers.Add(offer);

            repository.SaveChanges();

            return offer.Id;
        }
    }
}
