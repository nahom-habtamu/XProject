using domain.bid;
using domain.driver;
using domain.vehicle;
using dtos.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAllBidsForAuctionController : ControllerBase
{
    private readonly ILogger<GetAllBidsForAuctionController> _logger;
    private readonly BidRepository _bidRepo;
    private readonly DriverRepository _driverRepo;
    private readonly VehicleRepository _vehicleRepo;

    public GetAllBidsForAuctionController(
        ILogger<GetAllBidsForAuctionController> logger,
        BidRepository bidRepo,
        DriverRepository driverRepo,
        VehicleRepository vehicleRepo
    )
    {
        _logger = logger;
        _bidRepo = bidRepo;
        _driverRepo = driverRepo;
        _vehicleRepo = vehicleRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<GetAllBidsForAuctionItemResponseDto>> Call([FromRoute] string auctionId)
    {
        var allBidsForAuction = await _bidRepo.GetBidsForAuction(auctionId);
        List<GetAllBidsForAuctionItemResponseDto> parsedBids = await parseBidsToListOfDto(allBidsForAuction);
        return parsedBids;
    }

    private async Task<List<GetAllBidsForAuctionItemResponseDto>> parseBidsToListOfDto(
        List<Bid> allBidsForAuction
    )
    {
        var parsedBids = new List<GetAllBidsForAuctionItemResponseDto>();
        foreach (var bid in allBidsForAuction)
        {
            GetAllBidsForAuctionItemResponseDto? parsedBid = null;
            try
            {
                parsedBid = await parseToDto(bid);
            }
            finally
            {
                if (parsedBid != null)
                {
                    parsedBids.Add(parsedBid!);
                }
            }
        }

        return parsedBids;
    }

    private async Task<GetAllBidsForAuctionItemResponseDto> parseToDto(Bid b)
    {
        var driver = await _driverRepo.Get(b.DriverId);
        if (driver == null)
        {
            throw new Exception("Driver Not Found");
        }

        var vehicle = (await _vehicleRepo.GetVehiclesByDriver(driver.Id)).FirstOrDefault();
        if (vehicle == null)
        {
            throw new Exception("Driver Doesn't Have Vehicles Registered");
        }
        return new GetAllBidsForAuctionItemResponseDto
        {
            DriverId = driver.Id,
            DriverName = driver.FirstName + " " + driver.LastName,
            VehicleManufaturedDate = vehicle.ManufacturedDate,
            VehicleModel = vehicle.Model,
            VehicleImages = new List<Uri> {
               vehicle.CarImage,
            },
            VehicleInsuranceImage = vehicle.InsuranceImage,
            VehicleRating = 0
        };
    }
}
