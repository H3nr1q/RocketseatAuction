using Bogus;
using FluentAssertions;
using Moq;
using RockeseatAuction.API.Communication.Requests;
using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;
using RockeseatAuction.API.Services;
using RockeseatAuction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(auction => auction.Price, faker => faker.Random.Decimal(1, 700))
                .Generate();

            var offerRepository = new Mock<IOfferRepository>();

            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggedUser.Object,offerRepository.Object);

            var act = () => useCase.Execute(itemId, request);

            act.Should().NotThrow();

        }
    }
}
