using Microsoft.AspNetCore.Mvc;
using RockeseatAuction.API.Communication.Requests;
using RockeseatAuction.API.Filters;
using RockeseatAuction.API.UseCases.Offers.CreateOffer;

namespace RockeseatAuction.API.Controllers
{
    [ApiController]
    public class OfferController : RocketseatAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        [ServiceFilter(typeof(AuthenticationUserAttribute))]
        public IActionResult CreateOffer([FromRoute]int itemId, [FromBody]RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }
    }
}
