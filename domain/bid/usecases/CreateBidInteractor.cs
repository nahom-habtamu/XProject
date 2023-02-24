using domain.auction;
using domain.driver;
using dtos.bid;

namespace domain.bid.usecases;

public class CreateBidInteractor
{
    private readonly AuctionRepository _auctionRepo;
    private readonly DriverRepository _driverRepo;

    private readonly BidRepository _bidRepo;

    public CreateBidInteractor(
        AuctionRepository auctionRepo,
        DriverRepository driverRepo,
        BidRepository bidRepo
    )
    {
        _auctionRepo = auctionRepo;
        _driverRepo = driverRepo;
        _bidRepo = bidRepo;
    }

    public async Task<Bid> Call(CreateBidRequestDto requestDto)
    {
        await HandleWrongDriverId(requestDto);
        await HandleWrongAuctionId(requestDto);

        var bid = new Bid(
            requestDto.AuctionId!,
            requestDto.DriverId!,
            requestDto.PricePerKilogram,
            requestDto.AdditionalInformation!
        );

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