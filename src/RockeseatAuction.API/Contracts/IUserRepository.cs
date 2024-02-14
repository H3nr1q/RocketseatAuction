using RockeseatAuction.API.Entities;

namespace RockeseatAuction.API.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
