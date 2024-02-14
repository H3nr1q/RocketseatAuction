using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly RocketseatAuctionDbContext dbContext;
        public UserRepository(RocketseatAuctionDbContext dbContext) => this.dbContext = dbContext;

        public bool ExistUserWithEmail(string email)
        {
            return dbContext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email) => this.dbContext.Users.First(user => user.Email.Equals(email));

    }
}
