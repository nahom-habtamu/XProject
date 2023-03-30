using domain.bid;
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
        return await _bidRepo.Get(id);
    }
}