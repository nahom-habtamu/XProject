using domain.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAllBidsForAuctionController : ControllerBase
{
    private readonly ILogger<GetAllBidsForAuctionController> _logger;
    private readonly BidRepository _bidRepo;

    public GetAllBidsForAuctionController(
        ILogger<GetAllBidsForAuctionController> logger,
        BidRepository bidRepo
    )
    {
        _logger = logger;
        _bidRepo = bidRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Bid>> Call([FromRoute] string auctionId)
    {
        return await _bidRepo.GetBidsForAuction(auctionId);
    }
}
