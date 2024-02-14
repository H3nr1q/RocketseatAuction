using Bogus;
using FluentAssertions;
using Moq;
using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;
using RockeseatAuction.API.Enums;
using RockeseatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAictonUseCaseTest
    {
        [Fact]
        public void Success()
        {
            var entity = new Faker<Auction>()
                .RuleFor(auction => auction.Id, faker => faker.Random.Number(1, 10))
                .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
                .RuleFor(auction => auction.Starts, faker => faker.Date.Past())
                .RuleFor(auction => auction.Ends, faker => faker.Date.Future())
                .RuleFor(auction => auction.Items, (faker, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = faker.Random.Number(),
                        Name = faker.Commerce.ProductName(),
                        Brand = faker.Commerce.Department(),
                        BasePrice = faker.Random.Decimal(50,1000),
                        Condition = faker.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(new Auction());

            var useCase = new GetCurrentAictonUseCase(mock.Object);

            var auction = useCase.Execute();

            auction.Should().NotBeNull();
            auction.Id.Should().Be(auction.Id);
            auction.Name.Should().Be(auction.Name);
        }
    }
}
