using domain.bid;
using domain.driver;
using domain.vehicle;
using dtos.bid;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.bid;

[ApiController]
public class GetBidsForAuctionController : ControllerBase
{
    private readonly BidRepository _bidRepo;
    private readonly DriverRepository _driverRepo;
    private readonly VehicleRepository _vehicleRepo;

    public GetBidsForAuctionController(
        BidRepository bidRepo,
        DriverRepository driverRepo,
        VehicleRepository vehicleRepo
    )
    {
        _bidRepo = bidRepo;
        _driverRepo = driverRepo;
        _vehicleRepo = vehicleRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<GetBidsForAuctionItemResponseDto>> Call([FromRoute] string auctionId)
    {
        var allBidsForAuction = await _bidRepo.GetBidsForAuction(auctionId);
        List<GetBidsForAuctionItemResponseDto> parsedBids = await parseBidsToListOfDto(allBidsForAuction);
        return parsedBids;
    }

    private async Task<List<GetBidsForAuctionItemResponseDto>> parseBidsToListOfDto(
        List<Bid> allBidsForAuction
    )
    {
        var parsedBids = new List<GetBidsForAuctionItemResponseDto>();
        foreach (var bid in allBidsForAuction)
        {
            GetBidsForAuctionItemResponseDto? parsedBid = null;
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

    private async Task<GetBidsForAuctionItemResponseDto> parseToDto(Bid b)
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
        return new GetBidsForAuctionItemResponseDto
        {
            DriverId = driver.Id,
            DriverName = driver.Name,
            VehicleManufaturedDate = vehicle.ManufacturedDate,
            VehicleModel = vehicle.Model,
            VehicleImages = new List<string> {
               vehicle.CarImage,
            },
            VehicleInsuranceImage = vehicle.InsuranceImage,
            VehicleRating = 0
        };
    }
}
