using domain.auction;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAuctionController : ControllerBase
{
    private readonly ILogger<GetAuctionController> _logger;
    private readonly AuctionRepository _auctionRepo;

    public GetAuctionController(
        ILogger<GetAuctionController> logger,
        AuctionRepository auctionRepo
    )
    {
        _logger = logger;
        _auctionRepo = auctionRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<Auction> Call([FromQuery] string id)
    {
        var auction = await _auctionRepo.Get(id);
        if (auction == null) throw new Exception("Auction With This Id not Found");
        return auction;
    }
}
