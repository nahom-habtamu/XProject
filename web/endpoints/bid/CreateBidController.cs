using domain.auction;
using domain.bid;
using domain.driver;
using dtos.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class CreateBidController : ControllerBase
{
    private readonly ILogger<CreateBidController> _logger;
    private readonly AuctionRepository _auctionRepo;
    private readonly DriverRepository _driverRepo;
    private readonly BidRepository _bidRepo;

    public CreateBidController(
        ILogger<CreateBidController> logger,
        AuctionRepository auctionRepo,
        DriverRepository driverRepo,
        BidRepository bidRepo
    )
    {
        _logger = logger;
        _auctionRepo = auctionRepo;
        _driverRepo = driverRepo;
        _bidRepo = bidRepo;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<Bid> Call([FromBody] CreateBidRequestDto requestDto)
    {
        await HandleWrongDriverId(requestDto);
        await HandleWrongAuctionId(requestDto);

        var bid = Bid.parseFromDto(requestDto);
        await _bidRepo.Save(bid);
        return bid;
    }

    private async Task HandleWrongAuctionId(CreateBidRequestDto requestDto)
    {
        var auction = await _auctionRepo.Get(requestDto.AuctionId!);
        if (auction == null)
        {
            throw new Exception("Invalid Auction");
        }
    }

    private async Task HandleWrongDriverId(CreateBidRequestDto requestDto)
    {
        var driver = await _driverRepo.Get(requestDto.DriverId!);
        if (driver == null)
        {
            throw new Exception("Invalid Driver");
        }
    }
}
