using domain.cargoowner;
using dtos.auction;

namespace domain.auction.usecases;

public class CreateAuctionInteractor
{
    private readonly AuctionRepository _auctionRepo;
    private readonly CargoOwnerRepository _cargoOwnerRepo;

    public CreateAuctionInteractor(
        AuctionRepository auctionRepo,
        CargoOwnerRepository cargoOwnerRepo
    )
    {
        _auctionRepo = auctionRepo;
        _cargoOwnerRepo = cargoOwnerRepo;
    }

    public async Task<Auction> Call(CreateAuctionRequestDto requestDto)
    {
        await HandleInvalidCargoOwner(requestDto);
        Auction auctionToSave = Auction.parseAuctionFromDto(requestDto);
        await _auctionRepo.Save(auctionToSave);
        return auctionToSave;
    }

    private async Task HandleInvalidCargoOwner(CreateAuctionRequestDto requestDto)
    {
        var cargoOwner = await _cargoOwnerRepo.Get(requestDto.CargoOwnerId!);

        if (cargoOwner == null)
        {
            throw new Exception("Invalid Cargo Owner");
        }
    }
}