using domain.auction;
using domain.cargoowner;
using dtos.auction;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class GetAllAuctionsController : ControllerBase
{
    private readonly AuctionRepository _auctionRepo;
    private readonly CargoOwnerRepository _cargoOwnerRepo;

    public GetAllAuctionsController(
        AuctionRepository auctionRepo,
        CargoOwnerRepository cargoOwnerRepo
    )
    {
        _auctionRepo = auctionRepo;
        _cargoOwnerRepo = cargoOwnerRepo;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<List<GetAllAuctionsItemResponseDto>> Call()
    {
        var auctions = await _auctionRepo.GetAllAuctions();
        List<GetAllAuctionsItemResponseDto> parsedAuctions = await parseBidsToListOfDto(auctions);
        return parsedAuctions;
    }

    private async Task<List<GetAllAuctionsItemResponseDto>> parseBidsToListOfDto(
        List<Auction> auctions
    )
    {
        var parsedAuctions = new List<GetAllAuctionsItemResponseDto>();
        foreach (var auction in auctions)
        {
            GetAllAuctionsItemResponseDto? parsedAuction = null;
            try
            {
                parsedAuction = await parseToDto(auction);
            }
            finally
            {
                if (parsedAuction != null)
                {
                    parsedAuctions.Add(parsedAuction!);
                }
            }
        }

        return parsedAuctions;
    }

    private async Task<GetAllAuctionsItemResponseDto> parseToDto(Auction auction)
    {
        var cargoOwner = await _cargoOwnerRepo.Get(auction.CargoOwnerId);
        if (cargoOwner == null)
        {
            throw new Exception("CargoOwner Not Found");
        }
        return new GetAllAuctionsItemResponseDto
        {
            AuctionId = auction.Id,
            CargoOwnerId = cargoOwner.Id,
            CargoOwnerName = cargoOwner.Name,
            TypeOfCargo = auction.TypeOfCargo,
            WeightOfCargo = auction.TotalWeightOfCargo,
            CompanyName = "",
            MaxPricePerHundredKiloGram = auction.PriceIntervalPerHundredKiloGram!.Max,
            MinPricePerHundredKiloGram = auction.PriceIntervalPerHundredKiloGram.Min,
            MaxPickUpTime = auction.MaxPickUpTime,
            MinPickUpTime = auction.MinPickUpTime
        };
    }
}
