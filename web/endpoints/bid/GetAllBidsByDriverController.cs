using domain.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAllBidsByDriverController : ControllerBase
{
    private readonly BidRepository _bidRepo;

    public GetAllBidsByDriverController(
        BidRepository bidRepo
    )
    {
        _bidRepo = bidRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Bid>> Call([FromRoute] string driverId)
    {
        return await _bidRepo.GetBidsByDriver(driverId);
    }
}
