using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Entities;
using RockeseatAuction.API.Repositories;

namespace RockeseatAuction.API.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IUserRepository userRepository;

        public LoggedUser(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            this.contextAccessor=contextAccessor;
            this.userRepository=userRepository;
        }

        public User User()
        {
            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return userRepository.GetUserByEmail(email);    

        }

        private string TokenOnRequest()
        {
            var authentication = this.contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authentication["Bearer ".Length..];

        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
