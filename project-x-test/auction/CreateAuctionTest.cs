using domain.auction;
using domain.auction.usecases;
using domain.cargoowner;
using domain.common;
using dtos.auction;
using Moq;

namespace project_x_test.auction;

public class CreateAuctionTest
{
    [Fact]
    public void ThrowsInvalidOwnerExceptionWhenInvalidOwnerIsPassed()
    {
        var interactor = Setup();
        CreateAuctionRequestDto createAuctionDto = InitializeRequestDtoObject();
        Assert.ThrowsAsync<Exception>(() => interactor!.Call(createAuctionDto));
    }

    [Fact]
    public async Task ObjectIsSavedWhenCorrectOwnerIdIsPassed()
    {
        var interactor = Setup(
          new CargoOwner("1", "", new MobileNumber("0926849888"), "nahomhab@gmail.com", "Some address", "tradeLicence")
        );
        CreateAuctionRequestDto createAuctionDto = InitializeRequestDtoObject();
        await interactor!.Call(createAuctionDto);
    }
    private CreateAuctionInteractor Setup(CargoOwner? cargoOwner = null)
    {
        var mockAuctionRepo = new Mock<AuctionRepository>();
        var mockCargoOwnerRepo = new Mock<CargoOwnerRepository>();

        mockCargoOwnerRepo!.Setup(co => co.Get(It.IsAny<string>())).Returns(Task.Run(() => cargoOwner));

        var interactor = new CreateAuctionInteractor(
          mockAuctionRepo.Object,
          mockCargoOwnerRepo.Object
        );

        return interactor;
    }
    private static CreateAuctionRequestDto InitializeRequestDtoObject()
    {
        return new CreateAuctionRequestDto
        {
            CargoOwnerId = "1",
            DeliveryPlace = "soame adadjadn",
            MaxPickUpTime = "12:00:00",
            MinPickUpTime = "2:00:00",
            MaxPricePerHundredKiloGram = 1000,
            MinPricePerHundredKiloGram = 900,
            OtherInformationAboutCargo = "adanjanjnjfjaf",
            PickUpPlace = "Soem place",
            PlannedPickUpDate = DateTime.Now,
            TotalWeightOfCargo = 100,
            TypeOfCargo = "Some type"
        };
    }
}