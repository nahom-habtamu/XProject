using domain.auction;
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
        if (auction == null) throw new Exception("Auction With This Id Not Found");
        return auction;
    }
}
