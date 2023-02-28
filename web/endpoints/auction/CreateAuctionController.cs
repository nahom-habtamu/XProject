using domain.auction;
using domain.cargoowner;
using dtos.auction;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class CreateAuctionController : ControllerBase
{
    private readonly ILogger<CreateAuctionController> _logger;

    private readonly AuctionRepository _auctionRepo;
    private readonly CargoOwnerRepository _cargoOwnerRepo;

    public CreateAuctionController(
        ILogger<CreateAuctionController> logger,
        AuctionRepository auctionRepo,
        CargoOwnerRepository cargoOwnerRepo
    )
    {
        _logger = logger;
        _auctionRepo = auctionRepo;
        _cargoOwnerRepo = cargoOwnerRepo;
    }

    private async Task HandleInvalidCargoOwner(CreateAuctionRequestDto requestDto)
    {
        var cargoOwner = await _cargoOwnerRepo.Get(requestDto.CargoOwnerId!);

        if (cargoOwner == null)
        {
            throw new Exception("Invalid Cargo Owner");
        }
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<Auction> Call([FromBody] CreateAuctionRequestDto requestDto)
    {
        await HandleInvalidCargoOwner(requestDto);
        Auction auctionToSave = Auction.parseAuctionFromDto(requestDto);
        await _auctionRepo.Save(auctionToSave);
        return auctionToSave;
    }
}
