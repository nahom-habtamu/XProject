using domain.auction;
using domain.cargoowner;
using dtos.auction;
using Microsoft.AspNetCore.Mvc;

namespace web.endpoints.auction;

[ApiController]
public class SaveAuctionController : ControllerBase
{
    private readonly AuctionRepository _auctionRepo;
    private readonly CargoOwnerRepository _cargoOwnerRepo;

    public SaveAuctionController(
        AuctionRepository auctionRepo,
        CargoOwnerRepository cargoOwnerRepo
    )
    {
        _auctionRepo = auctionRepo;
        _cargoOwnerRepo = cargoOwnerRepo;
    }

    private async Task HandleInvalidCargoOwner(SaveAuctionRequestDto requestDto)
    {
        var cargoOwner = await _cargoOwnerRepo.Get(requestDto.CargoOwnerId!);

        if (cargoOwner == null)
        {
            throw new Exception("Invalid Cargo Owner");
        }
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<string> Call([FromBody] SaveAuctionRequestDto requestDto)
    {
        await HandleInvalidCargoOwner(requestDto);
        Auction auctionToSave = Auction.parseFromDto(requestDto);
        await _auctionRepo.Save(auctionToSave);
        return auctionToSave.Id;
    }
}
