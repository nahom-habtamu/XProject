using domain.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.bid;

[ApiController]
public class GetBidsByDriverController : ControllerBase
{
    private readonly BidRepository _bidRepo;

    public GetBidsByDriverController(
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
