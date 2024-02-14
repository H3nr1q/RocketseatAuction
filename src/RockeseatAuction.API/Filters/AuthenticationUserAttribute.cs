using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RockeseatAuction.API.Contracts;
using RockeseatAuction.API.Repositories;

namespace RockeseatAuction.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUserRepository userRepository;

        public AuthenticationUserAttribute(IUserRepository userRepository)
        {
            this.userRepository=userRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                //Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=
                var token = TokenOnRequest(context.HttpContext);

                var email = FromBase64String(token);

                var exist = userRepository.ExistUserWithEmail(email);

                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("E-mail not valid");   
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context) {
            var authentication = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }

            return authentication["Bearer ".Length..];

        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
