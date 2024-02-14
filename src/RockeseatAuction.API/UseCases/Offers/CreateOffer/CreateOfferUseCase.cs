using RockeseatAuction.API.Communication.Requests;
using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;
using RockeseatAuction.API.Repositories;
using RockeseatAuction.API.Services;

namespace RockeseatAuction.API.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser loggedUser;
        private readonly IOfferRepository offerRepository;

        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            this.loggedUser=loggedUser;
            this.offerRepository=offerRepository;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var user = this.loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,

            };

            offerRepository.Add( offer );   

            return offer.Id;
        }
    }
}
