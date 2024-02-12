using RockeseatAuction.API.Entities;
using RockeseatAuction.API.Repositories;

namespace RockeseatAuction.API.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor contextAccessor;

        public LoggedUser(IHttpContextAccessor httpContext)
        {
            this.contextAccessor = httpContext;
        }

        public User User()
        {
            var repository = new RocketseatAuctionDbContext();

            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return repository.Users.First(user => user.Email.Equals(email));

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
