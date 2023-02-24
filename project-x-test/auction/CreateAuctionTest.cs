using domain.auction;
using domain.auction.usecases;
using domain.cargoowner;
using domain.common;
using dtos.auction;
using Moq;

namespace project_x_test.auction;

public class CreateAuctionTest
{
    private Mock<AuctionRepository>? mockAuctionRepo;
    private Mock<CargoOwnerRepository>? mockCargoOwnerRepo;
    private CreateAuctionInteractor? interactor;

    [Fact]
    public void ThrowsInvalidOwnerExceptionWhenInvalidOwnerIsPassed()
    {
        Setup();
        CreateAuctionRequestDto createAuctionDto = InitializeRequestDtoObject();
        Assert.ThrowsAsync<Exception>(() => interactor!.Call(createAuctionDto));
    }

    [Fact]
    public async Task ObjectIsSavedWhenCorrectOwnerIdIsPassed()
    {
        Setup(
          new CargoOwner("1", "", new MobileNumber("0926849888"), "nahomhab@gmail.com", "Some address", "tradeLicence")
        );
        CreateAuctionRequestDto createAuctionDto = InitializeRequestDtoObject();
        await interactor!.Call(createAuctionDto);
        mockAuctionRepo!.Verify(ar => ar.Save(It.IsAny<Auction>()), Times.Once);
    }
    private void Setup(CargoOwner? cargoOwner = null)
    {
        mockAuctionRepo = new Mock<AuctionRepository>();
        mockCargoOwnerRepo = new Mock<CargoOwnerRepository>();

        setUpCargoOwnerStub(cargoOwner);

        interactor = new CreateAuctionInteractor(
          mockAuctionRepo.Object,
          mockCargoOwnerRepo.Object
        );
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

    private void setUpCargoOwnerStub(CargoOwner? cargoOwner)
    {
        mockCargoOwnerRepo!.Setup(co => co.Get(It.IsAny<string>())).Returns(Task.Run(() => cargoOwner));
    }
}