using domain.common;
using domain.driver;
using domain.vehicle;
using domain.vehicle.usecases;
using domain.vehicleowner;
using dtos.vehicle;
using Moq;

public class CreateVehicleTest
{
    [Fact]
    public void ThrowsExceptionWhenInvalidDriverIsPassed()
    {
        CreateVehicleInteractor interactor = SetupSUT();
        CreateVehicleRequestDto createVehicleDto = InitializeDto();
        Assert.ThrowsAsync<Exception>(() => interactor!.Call(createVehicleDto));
    }

    [Fact]
    public void ThrowsExceptionWhenInvalidOwnerIsPassed()
    {
        CreateVehicleInteractor interactor = SetupSUT(
            new Driver(
                "Nahom", "Habtamu",
                new MobileNumber("0926849888"),
                "someemail@gmail.com", Gender.MALE,
                DateTime.Now, "Some Address",
                new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
                "1"
            )
        );
        CreateVehicleRequestDto createVehicleDto = InitializeDto();
        Assert.ThrowsAsync<Exception>(() => interactor!.Call(createVehicleDto));
    }

    [Fact]
    public async Task ObjectIsSavedWhenCorrectOwnerAndDriverIdIsPassed()
    {
        CreateVehicleInteractor interactor = SetupSUT(
            new Driver(
                "Nahom", "Habtamu",
                new MobileNumber("0926849888"),
                "someemail@gmail.com", Gender.MALE,
                DateTime.Now, "Some Address",
                new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
                "1"
            ),
            new VehicleOwner(
                "nahom",
                new MobileNumber("0926849888"),
                "nahom@gmail.com", "CN",
                new Uri("https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq"),
                "ndhjahja", "pass", "1"
            )
        );
        CreateVehicleRequestDto createVehicleDto = InitializeDto();
        await interactor.Call(createVehicleDto);
    }

    private static CreateVehicleRequestDto InitializeDto()
    {
        return new CreateVehicleRequestDto
        {
            City = "Add",
            Color = "sasa",
            DriverId = "1",
            InsuranceExpiryDate = DateTime.Now,
            LibreExpiryDate = DateTime.Now,
            LoadCapacity = "High",
            LoadType = "Some Type",
            Make = "Another Make",
            ManufacturedDate = DateTime.Now,
            OwnerId = "1",
            Model = "SomeModel",
            PlateNumber = "someplate",
            Type = "SomeType",
        };
    }

    private CreateVehicleInteractor SetupSUT(
        Driver? driver = null,
        VehicleOwner? vehicleOwner = null
    )
    {
        var mockVehicleRepo = new Mock<VehicleRepository>();
        var mockDriverRepo = new Mock<DriverRepository>();
        var mockVehicleOwnerRepo = new Mock<VehicleOwnerRepository>();

        mockDriverRepo.Setup(dr => dr.Get(It.IsAny<string>())).Returns(Task.Run(() => driver));
        mockVehicleOwnerRepo.Setup(dr => dr.Get(It.IsAny<string>())).Returns(Task.Run(() => vehicleOwner));

        return new CreateVehicleInteractor(
            mockDriverRepo.Object,
            mockVehicleRepo.Object,
            mockVehicleOwnerRepo.Object
        );
    }
}