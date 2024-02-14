using Microsoft.AspNetCore.Mvc;
using RockeseatAuction.API.Entities;
using RockeseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RockeseatAuction.API.Controllers
{
    [ApiController]
    public class AuctionController : RocketseatAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAictonUseCase useCase)
        {
            var result = useCase.Execute();

            if(result is null)
                    return NoContent();

            return Ok(result);
        }
    }

    //Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=
}
