using domain.auction;
using domain.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAuctionController : ControllerBase
{
    private readonly AuctionRepository _auctionRepo;

    public GetAuctionController(AuctionRepository auctionRepo)
    {
        _auctionRepo = auctionRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<Auction> Call([FromQuery] string id)
    {
        var auction = await _auctionRepo.Get(id);
        if (auction == null) throw new NoDataFoundWithThisIdException(nameof(Auction), id);
        return auction;
    }
}
