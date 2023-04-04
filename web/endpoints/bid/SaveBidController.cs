using domain.auction;
using domain.bid;
using domain.driver;
using dtos.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.bid;

[ApiController]
public class SaveBidController : ControllerBase
{
    private readonly AuctionRepository _auctionRepo;
    private readonly DriverRepository _driverRepo;
    private readonly BidRepository _bidRepo;

    public SaveBidController(
        AuctionRepository auctionRepo,
        DriverRepository driverRepo,
        BidRepository bidRepo
    )
    {
        _auctionRepo = auctionRepo;
        _driverRepo = driverRepo;
        _bidRepo = bidRepo;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<string> Call([FromBody] SaveBidRequestDto requestDto)
    {
        await HandleWrongDriverId(requestDto);
        await HandleWrongAuctionId(requestDto);
        await HandleDuplicateAuctionAndDriver(requestDto);

        var bid = Bid.parseFromDto(requestDto);
        await _bidRepo.Save(bid);
        return bid.Id;
    }

    private async Task HandleDuplicateAuctionAndDriver(SaveBidRequestDto requestDto)
    {
        var bidsByCurrentDriver = await _bidRepo.GetBidsByDriver(requestDto.DriverId!);
        if (bidsByCurrentDriver.Any(b => b.AuctionId.Equals(requestDto.AuctionId)))
        {
            throw new Exception("Duplicate Bid For This Auction");
        }
    }

    private async Task HandleWrongAuctionId(SaveBidRequestDto requestDto)
    {
        var auction = await _auctionRepo.Get(requestDto.AuctionId!);
        if (auction == null)
        {
            throw new Exception("Invalid Auction");
        }
    }

    private async Task HandleWrongDriverId(SaveBidRequestDto requestDto)
    {
        var driver = await _driverRepo.Get(requestDto.DriverId!);
        if (driver == null)
        {
            throw new Exception("Invalid Driver");
        }
    }
}
