using Dapper;
using domain.vehicle;
using dtos.vehicle;
using persistence;
using persistence.driver;
using persistence.vehicle;
using persistence.vehicleowner;
using web.endpoints.vehicle;

namespace project_x_test.vehicle;

public class SaveVehicleControllerTest
{
    [Fact]
    public async Task SavingVehicleWithInvalidDriverIdShouldThrowAnException()
    {
        var sut = SetupSut();
        var saveVehicleRequest = InitDtoForSavingDataWithWrongValues();

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveVehicleRequest)
        );
    }

    [Fact]
    public async Task SavingVehicleWithInvalidOwnerIdShouldThrowAnExeption()
    {
        var sut = SetupSut();
        var saveVehicleRequest = InitDtoForSavingDataWithWrongValues();

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveVehicleRequest)
        );
    }

    [Fact]
    public async Task SavingVehicleWithDuplicatePlateNumberShouldThrowAnExeption()
    {
        var sut = SetupSut();
        var saveVehicleRequest = InitDtoForSavingDataWithWrongValues();

        await Assert.ThrowsAsync<Exception>(
            async () => await sut.Call(saveVehicleRequest)
        );
    }

    [Fact]
    public async Task SavingVehicleThatDoesntExistShouldInsertDataSuccessfully()
    {
        var getVehicleController = SetUpGetVehicleController();
        var sut = SetupSut();

        var saveVehicleRequest = InitDtoForSavingVehicleInitially();
        string savedVehicleId = await sut.Call(saveVehicleRequest);
        var savedVehicle = await getVehicleController.Call(savedVehicleId);

        saveVehicleRequest.Id = savedVehicleId;
        saveVehicleRequest.CreatedAt = savedVehicle.CreatedAt;
        var expectedVehicle = Vehicle.parseFromDto(saveVehicleRequest);
        Assert.Equal(expectedVehicle, savedVehicle);

        await CleanUp(savedVehicleId);
    }

    [Fact]
    public async Task SavingVehicleThatExistsShouldEditTheExisitingDataSuccessfully()
    {
        var getVehicleController = SetUpGetVehicleController();
        var sut = SetupSut();

        var initialRequest = InitDtoForSavingVehicleInitially();
        string initiallySavedVehicleId = await sut.Call(initialRequest);
        var initiallySavedVehicle = await getVehicleController.Call(initiallySavedVehicleId);

        var secondRequest = InitDtoForSavingVehicleSecondTime(
            initiallySavedVehicleId,
            initiallySavedVehicle.CreatedAt
        );
        string secondlySavedVehicleId = await sut.Call(secondRequest);

        var secondlySavedVehicle = await getVehicleController.Call(secondlySavedVehicleId);
        var expectedVehicle = Vehicle.parseFromDto(secondRequest);

        Assert.Equal(initiallySavedVehicleId, secondlySavedVehicleId);
        Assert.Equal(expectedVehicle, secondlySavedVehicle);

        await CleanUp(secondlySavedVehicleId);
    }


    private SaveVehicleController SetupSut()
    {
        var database = InitDbContext();
        var vehicleRepo = new VehicleRepositoryImpl(database);
        var driverRepo = new DriverRepositoryImpl(database);
        var vehicleOwnerRepo = new VehicleOwnerRepositoryImpl(database);

        var sut = new SaveVehicleController(
            vehicleRepo, driverRepo, vehicleOwnerRepo
        );
        return sut;
    }

    private GetVehicleController SetUpGetVehicleController()
    {
        var database = InitDbContext();
        var bidRepo = new VehicleRepositoryImpl(database);
        return new GetVehicleController(bidRepo);
    }

    private SaveVehicleRequestDto InitDtoForSavingDataWithWrongValues()
    {
        return new SaveVehicleRequestDto
        {
            DriverId = "wrongdriver",
            OwnerId = "wrongowner",
            CarImage = "3210df78-9132-44d8-9168-4f90e31616.jpg",
            InsuranceImage = "3210df78-9132-44d8-9168-4f90e3116.jpg",
            LibreImage = "3210df78-9132-44d8-9168-4f90e316006.jpg",
            City = "Addis",
            Color = "Green",
            DriverIdentificationDocumentBack = "dajdhajdav1e1e1hegydg.jpg",
            DriverIdentificationDocumentFront = "hjjjdhajdav1e1e1hegydg.jpg",
            InsuranceExpiryDate = new DateTime(2023, 3, 4),
            LibreExpiryDate = new DateTime(2023, 3, 5),
            ManufacturedDate = new DateTime(2020, 10, 10),
            LoadCapacity = "120CC",
            LoadType = "HEAVY",
            Make = "Make Make",
            Model = "Model 7726371",
            PlateNumber = "99099",
            Type = "BigCarType",
        };
    }

    private SaveVehicleRequestDto InitDtoForSavingVehicleInitially()
    {
        return new SaveVehicleRequestDto
        {
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e1",
            OwnerId = "2150df78-9132-44d8-9168-4f90e31616e3",
            CarImage = "3210df78-9132-44d8-9168-4f90e31616.jpg",
            InsuranceImage = "3210df78-9132-44d8-9168-4f90e3116.jpg",
            LibreImage = "3210df78-9132-44d8-9168-4f90e316006.jpg",
            City = "Addis",
            Color = "Green",
            DriverIdentificationDocumentBack = "dajdhajdav1e1e1hegydg.jpg",
            DriverIdentificationDocumentFront = "hjjjdhajdav1e1e1hegydg.jpg",
            InsuranceExpiryDate = new DateTime(2023, 3, 4),
            LibreExpiryDate = new DateTime(2023, 3, 5),
            ManufacturedDate = new DateTime(2020, 10, 10),
            LoadCapacity = "120CC",
            LoadType = "HEAVY",
            Make = "Make Make",
            Model = "Model 7726371",
            PlateNumber = "99099",
            Type = "BigCarType",
        };
    }

    private SaveVehicleRequestDto InitDtoForSavingVehicleSecondTime(
        string id,
        DateTime createdAt
    )
    {
        return new SaveVehicleRequestDto
        {
            Id = id,
            DriverId = "7210df78-9132-44d8-9168-4f90e31616e2",
            OwnerId = "2150df78-9132-44d8-9168-4f90e31616e2",
            CarImage = "3210df78-9132-44d8-9168-4f90e31616.jpg",
            InsuranceImage = "3210df78-9132-44d8-9168-4fiiiiii16.jpg",
            LibreImage = "3210df78-9132-44d8-9168-4f90eiiiiiiii316006.jpg",
            City = "Addis Aroge",
            Color = "Red",
            DriverIdentificationDocumentBack = "dajdhajdav1e1e1hegydg.jpg",
            DriverIdentificationDocumentFront = "hjjjdhajdav1e1e1hegydg.jpg",
            InsuranceExpiryDate = new DateTime(2023, 3, 4),
            LibreExpiryDate = new DateTime(2023, 3, 5),
            ManufacturedDate = new DateTime(2020, 10, 10),
            LoadCapacity = "320CC",
            LoadType = "HEAVY",
            Make = "Make Edited",
            Model = "Model 190007726371",
            PlateNumber = "99199",
            Type = "GiantCarType",
            CreatedAt = createdAt
        };
    }

    private async Task CleanUp(string id)
    {
        var database = InitDbContext();
        var connection = database.Get();
        await connection.ExecuteAsync("delete from Vehicle where id = " + "'" + id + "'");
    }

    private DatabaseContext InitDbContext()
    {
        return new DatabaseContext(new Npgsql.NpgsqlConnection(
            "Server=localhost;Port=5432;Database=ProjectX;User Id=postgres;Password=root"));
    }
}