using domain.auction;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAuctionsByCargoOwnerController : ControllerBase
{
    private readonly AuctionRepository _auctionRepo;

    public GetAuctionsByCargoOwnerController(
        AuctionRepository auctionRepo
    )
    {
        _auctionRepo = auctionRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<Auction>> Call([FromQuery] string cargoOwnerId)
    {
        return await _auctionRepo.GetAuctionsByCargoOwner(cargoOwnerId);
    }
}
