using domain.auction;
using domain.auction.usecases;
using dtos.auction;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class CreateAuctionController : ControllerBase
{
    private readonly CreateAuctionInteractor _createAuctionRepo;
    private readonly ILogger<CreateAuctionController> _logger;

    public CreateAuctionController(ILogger<CreateAuctionController> logger, CreateAuctionInteractor createAuction)
    {
        _logger = logger;
        _createAuctionRepo = createAuction;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<Auction> Call([FromBody] CreateAuctionRequestDto requestDto)
    {
        return await _createAuctionRepo.Call(requestDto);
    }
}
