using domain.bid;
using domain.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.bid;

[ApiController]
public class GetBidController : ControllerBase
{
    private readonly BidRepository _bidRepo;

    public GetBidController(BidRepository bidRepo)
    {
        _bidRepo = bidRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<Bid?> Call(string id)
    {
        var bid = await _bidRepo.Get(id);
        if(bid == null) throw new NoDataFoundWithThisIdException("Bid", id);
        return bid;
    }
}