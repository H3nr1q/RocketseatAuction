using RockeseatAuction.API.Repositories;
using RockeseatAuction.API.Entities;
using Microsoft.EntityFrameworkCore;
using RockeseatAuction.API.Contracts;

namespace RockeseatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAictonUseCase
    {
        private readonly IAuctionRepository repository;

        public GetCurrentAictonUseCase(IAuctionRepository repository) => this.repository=repository;

        public Auction? Execute()
        {
            return this.repository.GetCurrent();
            
        }
    }
}
